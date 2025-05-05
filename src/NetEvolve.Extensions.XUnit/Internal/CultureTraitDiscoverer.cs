namespace NetEvolve.Extensions.XUnit.Internal;

using System.Collections.Generic;
using NetEvolve.Extensions.XUnit;
using Xunit.Abstractions;

/// <summary>
/// Discoverer for all implementations of <see cref="CultureAttributeBase"/>.
/// </summary>
public sealed class CultureTraitDiscoverer : DiscovererBase
{
    /// <inheritdoc />
    public override IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
    {
        if (traitAttribute is null)
        {
            yield break;
        }

        var asHiddenCategory = GetNamedArgument<bool>(traitAttribute, nameof(CultureAttributeBase.AsHiddenCategory));
        if (asHiddenCategory)
        {
            yield break;
        }

        var category = GetNamedArgument<string>(traitAttribute, Internals.Category);
        if (string.IsNullOrWhiteSpace(category))
        {
            yield break;
        }

        var culture = GetNamedArgument<string>(traitAttribute, Internals.Culture);
        yield return new KeyValuePair<string, string>(category!, culture!);

        if (category!.Equals("SetCulture", StringComparison.Ordinal))
        {
            yield return new KeyValuePair<string, string>("SetUICulture", culture!);
        }
    }
}
