namespace NetEvolve.Extensions.XUnit.Internal;

using System.Collections.Generic;
using Xunit.Abstractions;
using NetEvolve.Extensions.XUnit;

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

        var id = GetNamedArgument(traitAttribute, Internals.Id);
        yield return new KeyValuePair<string, string>(category, id!);
    }
}
