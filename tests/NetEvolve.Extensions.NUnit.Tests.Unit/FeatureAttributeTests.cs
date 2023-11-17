namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="FeatureAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class FeatureAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="FeatureAttribute"/> without additional information.
    /// </summary>
    [Test]
    [Feature]
    [Feature("")]
    public async Task Feature_without_Id()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="FeatureAttribute"/> with numeric id.
    /// </summary>
    [Test]
    [Feature(123456)]
    public async Task Feature_with_LongId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [Test]
    [Feature("123456")]
    public async Task Feature_with_StringId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }
}
