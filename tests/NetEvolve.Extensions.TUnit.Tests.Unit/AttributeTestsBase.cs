﻿namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System.Runtime.CompilerServices;
using VerifyTUnit;

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
        if (methodName is null || TestContext.Current is null)
        {
            return [];
        }

        var context = TestContext.Current;

        var result = GetCategories(context).Union(GetProperties(context)).Distinct().ToList();

        return result;
    }

    private static IEnumerable<KeyValuePair<string, string>> GetCategories(TestContext context) =>
        context.TestDetails.Categories.Select(category => new KeyValuePair<string, string>(
            "TestCategory",
            category
        ));

    private static IEnumerable<KeyValuePair<string, string>> GetProperties(TestContext context) =>
        context.TestDetails.CustomProperties.Select(property => new KeyValuePair<string, string>(
            property.Key,
            property.Value
        ));

    protected static SettingsTask Verify<T>(T traits) => Verifier.Verify(traits);
}