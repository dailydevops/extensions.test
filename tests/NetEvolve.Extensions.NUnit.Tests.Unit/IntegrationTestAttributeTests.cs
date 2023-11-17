namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="IntegrationTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class IntegrationTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [IntegrationTest]
    [TestCase(nameof(IntegrationTest_without_parameters))]
    [TestCase(nameof(IntegrationTest_without_or_invalid_parameters))]
    public async Task IntegrationTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [IntegrationTest]
    private void IntegrationTest_without_parameters() { }
}
