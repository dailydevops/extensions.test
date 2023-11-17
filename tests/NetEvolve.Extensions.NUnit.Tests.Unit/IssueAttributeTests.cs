namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="IssueAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class IssueAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> without additional information.
    /// </summary>
    [Test]
    [Issue]
    [Issue("")]
    public async Task Issue_without_Id()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> with numeric id.
    /// </summary>
    [Test]
    [Issue(123456)]
    public async Task Issue_with_LongId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> with id.
    /// </summary>
    [Test]
    [Issue("123456")]
    public async Task Issue_with_StringId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }
}
