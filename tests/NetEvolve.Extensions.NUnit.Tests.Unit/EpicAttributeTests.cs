namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

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
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="EpicAttribute"/> with numeric id.
    /// </summary>
    [Test]
    [Epic(123456)]
    public async Task Epic_with_LongId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [Test]
    [Epic("123456")]
    public async Task Epic_with_StringId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }
}
