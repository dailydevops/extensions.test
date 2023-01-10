namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

public abstract class DiscovererBase : ITraitDiscoverer
{
    /// <inheritdoc />
    public abstract IEnumerable<KeyValuePair<string, string>> GetTraits(
        IAttributeInfo traitAttribute
    );

    private protected static string? GetNamedArgument(
        IAttributeInfo traitAttribute,
        string argumentName
    )
    {
        try
        {
            return traitAttribute.GetNamedArgument<string>(argumentName);
        }
        catch (ArgumentException)
        {
            // Ignore
        }
        return null;
    }
}
