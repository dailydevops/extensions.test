namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="FunctionalTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class FunctionalTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [FunctionalTest]
    [TestCase(nameof(FunctionalTest_without_parameters))]
    [TestCase(nameof(FunctionalTest_without_or_invalid_parameters))]
    public async Task FunctionalTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [FunctionalTest]
    public void FunctionalTest_without_parameters() { }
}
