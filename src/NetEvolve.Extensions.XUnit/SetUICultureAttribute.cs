namespace NetEvolve.Extensions.XUnit;

using System;
using System.Globalization;
using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Based on the value passed as UI culture, the marked test is executed.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    Inherited = false
)]
public sealed class SetUICultureAttribute : CultureAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetUICultureAttribute"/> class.
    /// </summary>
    public SetUICultureAttribute()
        : base("SetUICulture", string.Empty, false) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetUICultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">UI culture to use.</param>
    /// <param name="asHiddenCategory">If <see langword="true"/>, this test will be hidden from test explorer.</param>
    public SetUICultureAttribute(string culture, bool asHiddenCategory = false)
        : base("SetUICulture", culture, asHiddenCategory) { }

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
}
