﻿namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using VerifyTests;
using VerifyXunit;
using Xunit.Abstractions;
using Xunit.Sdk;

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
        if (methodName == null)
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

        var messageSink = new NullMessageSink();
        var result = GetTraits(methodInfo.CustomAttributes, messageSink)
            .Union(GetTraits(classType.CustomAttributes, messageSink))
            .Union(GetTraits(classType.Assembly.CustomAttributes, messageSink))
            .Distinct()
            .ToList();

        return result;
    }

    private static List<KeyValuePair<string, string>> GetTraits(
        IEnumerable<CustomAttributeData> customAttributes,
        IMessageSink messageSink
    )
    {
        var result = new List<KeyValuePair<string, string>>();

        foreach (var traitAttributeData in customAttributes)
        {
            var traitAttributeType = traitAttributeData.AttributeType;
            if (
                !typeof(ITraitAttribute)
                    .GetTypeInfo()
                    .IsAssignableFrom(traitAttributeType.GetTypeInfo())
            )
            {
                continue;
            }

            var discovererAttributeData = FindDiscovererAttributeType(
                traitAttributeType.GetTypeInfo()
            );
            if (discovererAttributeData == null)
            {
                continue;
            }

            var discoverer = ExtensibilityPointFactory.GetTraitDiscoverer(
                messageSink,
                Reflector.Wrap(discovererAttributeData)
            );
            if (discoverer == null)
            {
                continue;
            }

            var traits = discoverer.GetTraits(Reflector.Wrap(traitAttributeData));
            if (traits != null)
            {
                result.AddRange(traits);
            }
        }

        return result;
    }

    private static CustomAttributeData? FindDiscovererAttributeType(TypeInfo traitAttribute)
    {
        var typeChecking = traitAttribute;
        CustomAttributeData? result;
        do
        {
            result = typeChecking.CustomAttributes.FirstOrDefault(isTraitDiscovererAttribute);
            typeChecking = traitAttribute.BaseType.GetTypeInfo();
        } while (result == null && typeChecking != null);

        return result;

        static bool isTraitDiscovererAttribute(CustomAttributeData t) =>
            t.AttributeType == typeof(TraitDiscovererAttribute);
    }

    protected static SettingsTask Verify<T>(T traits) =>
        Verifier.Verify(traits).UseDirectory("../_snapshot");
}
