namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetEvolve.Extensions.MSTest.Internal;
using VerifyMSTest;
using VerifyTests;

public abstract class AttributeTestsBase : VerifyBase
{
    protected SettingsTask VerifyMSTest<T>(T traits) => Verify(traits);

    /// <summary>
    /// Gets the Traits from the given Method name
    /// </summary>
    /// <param name="methodName">Name of the caller Method</param>
    /// <returns>List of <see cref="KeyValuePair{TKey,TValue}"/></returns>
    protected IEnumerable<KeyValuePair<string, string>> GetProperties(
        [CallerMemberName] string? methodName = null
    )
    {
        if (string.IsNullOrWhiteSpace(methodName))
        {
            throw new ArgumentNullException(nameof(methodName));
        }

        var owningType = GetType();
        var methodInfo = owningType.GetMethod(
            methodName,
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        );

        if (methodInfo is null)
        {
            return [];
        }

        var categories = GetTestCategoryBaseAttributes(methodInfo).ToArray();
        if (categories.Length == 0)
        {
            categories = [.. categories, .. GetTestCategoryBaseAttributes(owningType)];
        }

        if (categories.Length == 0)
        {
            categories =
            [
                .. categories,
                .. GetTestCategoryBaseAttributes(owningType.Module.Assembly),
            ];
        }

        if (categories.Length == 0)
        {
            return [];
        }

        return categories
            .Where(x => x.Key is not null && !string.IsNullOrWhiteSpace(x.Value))
            .Distinct();
    }

    private IEnumerable<KeyValuePair<string, string>> GetTestCategoryBaseAttributes(
        Assembly assembly
    )
    {
        if (assembly is null)
        {
            yield break;
        }

        var attributes = assembly.GetCustomAttributes<TestCategoryBaseAttribute>();
        if (attributes is null)
        {
            yield break;
        }

        foreach (var attribute in attributes)
        {
            if (attribute is null)
            {
                continue;
            }

            foreach (var testCategory in attribute.TestCategories)
            {
                if (string.IsNullOrWhiteSpace(testCategory))
                {
                    continue;
                }

                yield return new KeyValuePair<string, string>("TestCategory", testCategory);

                if (
                    attribute is TestCategoryWithIdBaseAttribute attributeWithId
                    && !string.IsNullOrWhiteSpace(attributeWithId.Id)
                )
                {
                    yield return new KeyValuePair<string, string>(
                        testCategory,
                        attributeWithId.Id!
                    );
                }
            }
        }
    }

    private IEnumerable<KeyValuePair<string, string>> GetTestCategoryBaseAttributes(
        MemberInfo? member
    )
    {
        if (member is null)
        {
            yield break;
        }

        var attributes = member.GetCustomAttributes<TestCategoryBaseAttribute>(true);
        if (attributes is null)
        {
            yield break;
        }

        foreach (var attribute in attributes)
        {
            if (attribute is null)
            {
                continue;
            }

            foreach (var testCategory in attribute.TestCategories)
            {
                if (string.IsNullOrWhiteSpace(testCategory))
                {
                    continue;
                }

                yield return new KeyValuePair<string, string>("TestCategory", testCategory);

                if (
                    attribute is TestCategoryWithIdBaseAttribute attributeWithId
                    && !string.IsNullOrWhiteSpace(attributeWithId.Id)
                )
                {
                    yield return new KeyValuePair<string, string>(
                        testCategory,
                        attributeWithId.Id!
                    );
                }
            }
        }
    }
}
