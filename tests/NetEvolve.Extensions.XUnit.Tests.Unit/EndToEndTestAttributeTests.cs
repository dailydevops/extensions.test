namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="EndToEndTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class EndToEndTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [EndToEndTest]
    [InlineData(nameof(EndToEndTest_without_parameters))]
    public async Task EndToEndTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [EndToEndTest]
    [SuppressMessage("Usage", "xUnit1013", Justification = "Reviewed.")]
    public void EndToEndTest_without_parameters() { }
}
