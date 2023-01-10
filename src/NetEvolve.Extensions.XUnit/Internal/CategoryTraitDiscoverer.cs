namespace NetEvolve.Extensions.XUnit.Internal;

using System.Collections.Generic;
using Xunit.Abstractions;
using NetEvolve.Extensions.XUnit;

public sealed class CategoryTraitDiscoverer : DiscovererBase
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

        yield return new KeyValuePair<string, string>(Internals.Category, category!);
        yield return new KeyValuePair<string, string>(Internals.TestCategory, category!);

        var id = GetNamedArgument(traitAttribute, Internals.Id);

        if (!string.IsNullOrWhiteSpace(id))
        {
            yield return new KeyValuePair<string, string>(category!, id!);
        }
    }
}
