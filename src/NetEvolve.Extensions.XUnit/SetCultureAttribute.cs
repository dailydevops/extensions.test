namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;
using System;
using System.Globalization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
public sealed class SetCultureAttribute : CultureAttributeBase
{
    public SetCultureAttribute() : base("SetCulture", string.Empty) { }

    public SetCultureAttribute(string culture) : base("SetCulture", culture) { }

    protected override bool SetCurrentCulture(CultureInfo culture)
    {
        if (CultureInfo.CurrentCulture != culture)
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            CultureInfo.CurrentCulture?.ClearCachedData();
            CultureInfo.DefaultThreadCurrentCulture?.ClearCachedData();
#endif
            return true;
        }

        return false;
    }
}
