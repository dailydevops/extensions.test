namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="FeatureAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class FeatureAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="FeatureAttribute"/> without additional information.
    /// </summary>
    [Fact]
    [Feature]
    [Feature("")]
    public async Task Feature_without_Id()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="FeatureAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [Feature(123456)]
    public async Task Feature_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [Fact]
    [Feature("123456")]
    public async Task Feature_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
