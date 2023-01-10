namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="IntegrationTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class IntegrationTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [IntegrationTest]
    [InlineData(nameof(IntegrationTest_without_parameters))]
    public async Task IntegrationTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [IntegrationTest]
    [SuppressMessage("Usage", "xUnit1013", Justification = "Reviewed.")]
    public void IntegrationTest_without_parameters() { }
}
