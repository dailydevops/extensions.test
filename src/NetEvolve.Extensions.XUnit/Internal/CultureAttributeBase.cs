namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using System.Globalization;
using System.Reflection;
using Xunit.Sdk;

/// <summary>
/// Abstract class implementation of <see cref="ITraitAttribute"/>.
/// Provides basic functionality for culture-based testing.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CultureTraitDiscoverer, Namespaces.Assembly)]
#pragma warning disable S3376 // Attribute, EventArgs, and Exception type names should end with the type being extended
public abstract class CultureAttributeBase : BeforeAfterTestAttribute, ITraitAttribute
#pragma warning restore S3376 // Attribute, EventArgs, and Exception type names should end with the type being extended
{
    private readonly CultureInfo _culture;

    private CultureInfo? _originalCulture;
    private bool _changed;

    /// <summary>
    /// Category
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Culture
    /// </summary>
    public string Culture { get; }

    /// <inheritdoc/>
    protected CultureAttributeBase(string category, string culture)
    {
        Category = category;
        Culture = culture;
        _culture = CreateCultureInfo(culture);
    }

    /// <inheritdoc/>
    public override void After(MethodInfo methodUnderTest)
    {
        if (_changed)
        {
            _ = SetCulture(_originalCulture!);
        }
    }

    /// <inheritdoc/>
    public override void Before(MethodInfo methodUnderTest)
    {
        _originalCulture = CultureInfo.CurrentCulture;

        _changed = SetCulture(_culture);
    }

    private protected static CultureInfo CreateCultureInfo(string culture) =>
        new CultureInfo(culture, false);

    private protected virtual bool SetCulture(CultureInfo culture)
    {
        if (CultureInfo.CurrentCulture != culture)
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return true;
        }

        return false;
    }
}
