namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="EpicAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class EpicAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="EpicAttribute"/> without additional information.
    /// </summary>
    [Test]
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
    [Test]
    [Epic(123456)]
    public async Task Epic_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [Test]
    [Epic("123456")]
    public async Task Epic_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
