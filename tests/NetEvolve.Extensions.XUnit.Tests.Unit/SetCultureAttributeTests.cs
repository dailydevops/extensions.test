namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[ExcludeFromCodeCoverage]
[UsesVerify]
public class SetCultureAttributeTests : AttributeTestsBase
{
    [Fact]
    [SetCulture("en")]
    public async Task Execute_English()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetCulture]
    public async Task Execute_Invariant()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetCulture("de")]
    public async Task Execute_German()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetCulture("de-DE")]
    public async Task Execute_German_Germany()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }
}
