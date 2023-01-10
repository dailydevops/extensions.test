namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using global::NUnit.Framework;

[ExcludeFromCodeCoverage]
public class SetCultureAttributeTests : AttributeTestsBase
{
    [Test]
    [SetCulture("en")]
    public async Task Execute_English()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(properties.Union(translations));
    }

    [Test]
    [SetCulture("")]
    public async Task Execute_Invariant()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(properties.Union(translations));
    }

    [Test]
    [SetCulture("de")]
    public async Task Execute_German()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(properties.Union(translations));
    }

    [Test]
    [SetCulture("de-DE")]
    public async Task Execute_German_Germany()
    {
        var properties = GetProperties();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(properties.Union(translations));
    }
}
