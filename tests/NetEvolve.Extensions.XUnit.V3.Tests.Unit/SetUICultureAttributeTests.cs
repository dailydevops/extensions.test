namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

[ExcludeFromCodeCoverage]
public class SetUICultureAttributeTests : AttributeTestsBase
{
    [Fact(Skip = "Flaky, will deal with this later.")]
    [SetUICulture("en")]
    public async Task Execute_English()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetUICulture]
    public async Task Execute_Invariant()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact(Skip = "Flaky, will deal with this later.")]
    [SetUICulture("de")]
    public async Task Execute_German()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetUICulture("de-DE")]
    public async Task Execute_German_Germany()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Translation", Translations.HelloWorld },
        };

        _ = await Verify(traits.Union(translations));
    }
}
