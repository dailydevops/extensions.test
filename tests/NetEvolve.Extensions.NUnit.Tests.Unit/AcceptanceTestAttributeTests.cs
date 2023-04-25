namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="AcceptanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class AcceptanceTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [AcceptanceTest]
    [TestCase(nameof(AcceptanceTest_without_parameters))]
    [TestCase(nameof(AcceptanceTest_without_or_invalid_parameters))]
    public async Task AcceptanceTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [AcceptanceTest]
    public void AcceptanceTest_without_parameters() { }
}
