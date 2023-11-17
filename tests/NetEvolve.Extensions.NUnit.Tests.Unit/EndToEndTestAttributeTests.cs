namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="EndToEndTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class EndToEndTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [EndToEndTest]
    [TestCase(nameof(EndToEndTest_without_parameters))]
    [TestCase(nameof(EndToEndTest_without_or_invalid_parameters))]
    public async Task EndToEndTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [EndToEndTest]
    private void EndToEndTest_without_parameters() { }
}
