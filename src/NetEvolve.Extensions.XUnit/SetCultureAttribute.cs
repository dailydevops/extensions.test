namespace NetEvolve.Extensions.XUnit;

using System;
using System.Globalization;
using System.Reflection;
using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Based on the value passed as culture, the marked test is executed.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
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
        : this(string.Empty, string.Empty, false) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">Culture to use.</param>
    /// <param name="asHiddenCategory">If <see langword="true"/>, this test will be hidden from test explorer.</param>
    public SetCultureAttribute(string culture, bool asHiddenCategory = false)
        : this(culture, culture, asHiddenCategory) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">Culture to use.</param>
    /// <param name="uiCulture">UI culture to use.</param>
    /// <param name="asHiddenCategory">If <see langword="true"/>, this test will be hidden from test explorer.</param>
    public SetCultureAttribute(string culture, string? uiCulture, bool asHiddenCategory = false)
        : base("SetCulture", culture, asHiddenCategory)
    {
        if (string.IsNullOrWhiteSpace(uiCulture))
        {
            uiCulture = string.Empty;
        }

        _uiCulture = CreateCultureInfo(uiCulture!);
    }

    /// <inheritdoc/>
    public override void After(MethodInfo methodUnderTest)
    {
        base.After(methodUnderTest);

        if (_changed)
        {
            _ = SetUICulture(_originalUICulture!);
        }
    }

    /// <inheritdoc/>
    public override void Before(MethodInfo methodUnderTest)
    {
        base.Before(methodUnderTest);

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
}
