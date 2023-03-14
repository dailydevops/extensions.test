namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;
using System;
using System.Globalization;

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
}
