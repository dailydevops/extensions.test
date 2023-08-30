namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using VerifyTests;
using VerifyXunit;
using Xunit.Sdk;

/// <summary>
/// Base class for Trait Attribute tests
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public abstract class AttributeTestsBase
{
    /// <summary>
    /// Gets the Traits from the given Method name
    /// </summary>
    /// <param name="methodName">Name of the caller Method</param>
    /// <returns>List of <see cref="KeyValuePair{TKey,TValue}"/></returns>
    protected IEnumerable<KeyValuePair<string, string>> GetTraits(
        [CallerMemberName] string? methodName = null
    )
    {
        if (methodName == null)
        {
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }

        var classType = GetType();
        var methodInfo = classType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        var result = TraitHelper.GetTraits(methodInfo).Distinct().ToList();

        return result;
    }

    protected static SettingsTask Verify<T>(T traits) =>
        Verifier.Verify(traits).UseDirectory("../_snapshot");
}
