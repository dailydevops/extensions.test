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
    public override IEnumerable<KeyValuePair<string, string>> GetTraits(
        IAttributeInfo traitAttribute
    )
    {
        if (traitAttribute is null)
        {
            yield break;
        }

        var category = GetNamedArgument(traitAttribute, Internals.Category);
        if (string.IsNullOrWhiteSpace(category))
        {
            yield break;
        }

        var culture = GetNamedArgument(traitAttribute, Internals.Culture);
        yield return new KeyValuePair<string, string>(category!, culture!);

        if (category!.Equals("SetCulture", System.StringComparison.Ordinal))
        {
            yield return new KeyValuePair<string, string>("SetUICulture", culture!);
        }
    }
}
