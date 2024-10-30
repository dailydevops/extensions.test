namespace NetEvolve.Extensions.XUnit.V3;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using NetEvolve.Extensions.XUnit.V3.Internal;
using Xunit.Internal;
using Xunit.v3;

/// <summary>
/// Based on the value passed as culture, the marked test is executed.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
public sealed class SetCultureAttribute : CultureAttributeBase
{
    private readonly CultureInfo _uiCulture;
    private CultureInfo? _originalUICulture;
    private bool _changed;

    /// <summary>
    /// UI culture
    /// </summary>
    public string? UICulture { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    public SetCultureAttribute()
        : this(string.Empty, string.Empty) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">Culture to use.</param>
    public SetCultureAttribute(string culture)
        : this(culture, culture) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">Culture to use.</param>
    /// <param name="uiCulture">UI culture to use.</param>
    public SetCultureAttribute(string culture, string? uiCulture)
        : base("SetCulture", culture)
    {
        if (string.IsNullOrWhiteSpace(uiCulture))
        {
            uiCulture = string.Empty;
        }

        _uiCulture = CreateCultureInfo(uiCulture!);
    }

    /// <inheritdoc/>
    public override async ValueTask After(MethodInfo methodUnderTest, IXunitTest test)
    {
        await base.After(methodUnderTest, test).ConfigureAwait(false);

        if (_changed)
        {
            _ = SetUICulture(_originalUICulture!);
        }
    }

    /// <inheritdoc/>
    public override async ValueTask Before(MethodInfo methodUnderTest, IXunitTest test)
    {
        await base.Before(methodUnderTest, test).ConfigureAwait(false);

        _originalUICulture = CultureInfo.CurrentUICulture;
        _changed = SetUICulture(_uiCulture);
    }

    private static bool SetUICulture(CultureInfo culture)
    {
        if (CultureInfo.CurrentUICulture != culture)
        {
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            return true;
        }

        return false;
    }

    /// <inheritdoc />
    public override IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "SetCulture", Culture },
            { "SetUICulture", Culture },
        };

        return result.CastOrToReadOnlyList();
    }
}
