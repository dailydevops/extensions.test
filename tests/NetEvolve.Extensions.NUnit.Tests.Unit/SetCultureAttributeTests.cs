namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using global::NUnit.Framework;

[ExcludeFromCodeCoverage]
public class SetCultureAttributeTests : AttributeTestsBase
{
    [Test]
    [SetCulture("en")]
    [SetUICulture("en")]
    public async Task Execute_English()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(properties.Union(translations));
    }

    [Test]
    [SetCulture("")]
    [SetUICulture("")]
    public async Task Execute_Invariant()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(properties.Union(translations));
    }

    [Test]
    [SetCulture("de")]
    [SetUICulture("de")]
    public async Task Execute_German()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(properties.Union(translations));
    }

    [Test]
    [SetCulture("de-DE")]
    [SetUICulture("de-DE")]
    public async Task Execute_German_Germany()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(properties.Union(translations));
    }
}
