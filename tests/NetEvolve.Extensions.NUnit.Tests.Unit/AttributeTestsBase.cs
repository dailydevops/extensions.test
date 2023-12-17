namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using global::NUnit.Framework;
using global::NUnit.Framework.Internal;
using global::NUnit.Framework.Internal.Builders;
using VerifyNUnit;
using VerifyTests;

/// <summary>
/// Base class for Trait Attribute tests
/// </summary>
[ExcludeFromCodeCoverage]
[TestFixture]
public abstract class AttributeTestsBase
{
    private static readonly List<string> _excludeKeys = new List<string>
    {
        PropertyNames.AppDomain,
        PropertyNames.JoinType,
        PropertyNames.ProcessId,
        PropertyNames.ProviderStackTrace,
        PropertyNames.SkipReason
    };

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
        var methodInfo = classType.GetMethod(
            methodName,
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        );

        if (methodInfo is null)
        {
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }

        var test = new DefaultTestCaseBuilder().BuildFrom(new MethodWrapper(classType, methodInfo));
        var result = new List<KeyValuePair<string, string>>();

        foreach (var key in test.Properties.Keys)
        {
            if (_excludeKeys.Any(x => x.Equals(key, StringComparison.OrdinalIgnoreCase)))
            {
                continue;
            }

            foreach (string value in test.Properties[key])
            {
                result.Add(
                    new KeyValuePair<string, string>(
                        key.Replace(
                            PropertyNames.Category,
                            "TestCategory",
                            StringComparison.Ordinal
                        ),
                        value
                    )
                );
            }
        }

        return result.Distinct();
    }

    protected static SettingsTask Verify<T>(T traits) =>
        Verifier.Verify(traits).UseDirectory("../_snapshot");
}
