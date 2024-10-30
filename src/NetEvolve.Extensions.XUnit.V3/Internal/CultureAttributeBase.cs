namespace NetEvolve.Extensions.XUnit.V3.Internal;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xunit.v3;

/// <summary>
/// Abstract class implementation of <see cref="ITraitAttribute"/>.
/// Provides basic functionality for culture-based testing.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
//[TraitDiscoverer(Namespaces.CultureTraitDiscoverer, Namespaces.Assembly)]
#pragma warning disable S3376 // Attribute, EventArgs, and Exception type names should end with the type being extended
#pragma warning disable CA1710 // Identifiers should have correct suffix
public abstract class CultureAttributeBase : Attribute, IBeforeAfterTestAttribute, ITraitAttribute
#pragma warning restore CA1710 // Identifiers should have correct suffix
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
    public virtual ValueTask After(MethodInfo methodUnderTest, IXunitTest test)
    {
        if (_changed)
        {
            _ = SetCulture(_originalCulture!);
        }

        return new ValueTask();
    }

    /// <inheritdoc/>
    public virtual ValueTask Before(MethodInfo methodUnderTest, IXunitTest test)
    {
        _originalCulture = CultureInfo.CurrentCulture;

        _changed = SetCulture(_culture);

        return new ValueTask();
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

    /// <inheritdoc />
    public abstract IReadOnlyCollection<KeyValuePair<string, string>> GetTraits();
}
