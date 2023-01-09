namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework.Internal;
using global::NUnit.Framework.Internal.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using VerifyTests;
using VerifyNUnit;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Base class for Trait Attribute tests
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class AttributeTestsBase
{
    /// <summary>
    /// Gets the Traits from the given Method name
    /// </summary>
    /// <param name="methodName">Name of the caller Method</param>
    /// <returns>List of <see cref="KeyValuePair{TKey,TValue}"/></returns>
    protected IEnumerable<KeyValuePair<string, string>> GetProperties(
        [CallerMemberName] string? methodName = null
    )
    {
        if (methodName is null)
        {
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }

        var classType = GetType();
        var methodInfo = classType.GetMethod(methodName);

        if (methodInfo is null)
        {
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }

        var test = new DefaultTestCaseBuilder().BuildFrom(new MethodWrapper(classType, methodInfo));
        var result = new List<KeyValuePair<string, string>>();

        foreach (var key in test.Properties.Keys)
        {
            foreach (string value in test.Properties[key])
            {
                result.Add(new KeyValuePair<string, string>(key, value));
            }
        }

        return result.Distinct();
    }

    protected static SettingsTask Verify<T>(T traits) =>
        Verifier.Verify(traits).UseDirectory("_snapshot");
}
