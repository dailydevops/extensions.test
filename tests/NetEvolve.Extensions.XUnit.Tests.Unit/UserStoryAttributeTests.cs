namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="UserStoryAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class UserStoryAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="UserStoryAttribute"/> without additional information.
    /// </summary>
    [Fact]
    [UserStory]
    [UserStory("")]
    public async Task UserStory_without_Id()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="UserStoryAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [UserStory(123456)]
    public async Task UserStory_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="UserStoryAttribute"/> with id.
    /// </summary>
    [Fact]
    [UserStory("123456")]
    public async Task UserStory_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
