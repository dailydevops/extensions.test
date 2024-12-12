namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using VerifyTests;
using VerifyXunit;
using Xunit.v3;

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
    protected IEnumerable<KeyValuePair<string, string>> GetTraits(
        [CallerMemberName] string? methodName = null
    )
    {
        if (methodName is null)
        {
            return [];
        }

        var classType = GetType();

#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        var methodInfo = classType.GetMethod(
            methodName,
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        );
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields

        if (methodInfo is null)
        {
            return [];
        }

        var assemblyTraits = ExtensibilityPointFactory.GetAssemblyTraits(classType.Assembly);
        var classTraits = ExtensibilityPointFactory.GetClassTraits(classType, assemblyTraits);
        var methodTraits = ExtensibilityPointFactory.GetMethodTraits(methodInfo, classTraits);

        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var trait in methodTraits)
        {
            result.Add(trait.Key, string.Join(", ", trait.Value));
        }

        return [.. result];
    }

    protected static SettingsTask Verify<T>(T traits) => Verifier.Verify(traits);
}
