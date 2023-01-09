namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using System.Globalization;
using System.Reflection;
using Xunit.Sdk;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CultureTraitDiscoverer, Namespaces.Assembly)]
public abstract class CultureAttributeBase : BeforeAfterTestAttribute, ITraitAttribute
{
    private readonly CultureInfo _culture;

    private CultureInfo? _originalCulture;
    private bool _changed;

    public string Category { get; }
    public string Id { get; }

    /// <inheritdoc/>
    protected CultureAttributeBase(string category, string culture)
    {
        Category = category;
        Id = culture;
        _culture = CreateCultureInfo(culture);
    }

    /// <inheritdoc/>
    public override void Before(MethodInfo methodUnderTest)
    {
        _originalCulture = CultureInfo.CurrentCulture;

        _changed = SetCurrentCulture(_culture);
    }

    /// <inheritdoc/>
    public override void After(MethodInfo methodUnderTest)
    {
        if (_changed)
        {
            _ = SetCurrentCulture(_originalCulture!);
        }
    }

    private static CultureInfo CreateCultureInfo(string culture)
        =>
#if NETSTANDARD2_0_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        new CultureInfo(culture, false);
#else
        return new CultureInfo(x);
#endif


    protected abstract bool SetCurrentCulture(CultureInfo culture);
}
