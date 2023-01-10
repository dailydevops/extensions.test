namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="EpicAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class EpicAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="EpicAttribute"/> without additional information.
    /// </summary>
    [Fact]
    [Epic]
    [Epic("")]
    public async Task Epic_without_Id()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="EpicAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [Epic(123456)]
    public async Task Epic_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [Fact]
    [Epic("123456")]
    public async Task Epic_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
