namespace NetEvolve.Extensions.XUnit.V3;

using System;
using System.Collections.Generic;
using System.Globalization;
using NetEvolve.Extensions.XUnit.V3.Internal;
using Xunit.Internal;

/// <summary>
/// Based on the value passed as UI culture, the marked test is executed.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
public sealed class SetUICultureAttribute : CultureAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetUICultureAttribute"/> class.
    /// </summary>
    public SetUICultureAttribute()
        : base("SetUICulture", string.Empty) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetUICultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">UI culture to use.</param>
    public SetUICultureAttribute(string culture)
        : base("SetUICulture", culture) { }

    private protected override bool SetCulture(CultureInfo culture)
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
            { "SetUICulture", Culture },
        };

        return result.CastOrToReadOnlyList();
    }
}
