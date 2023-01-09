namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="FunctionalTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class FunctionalTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [FunctionalTest]
    [InlineData(nameof(FunctionalTest_without_parameters))]
    public async Task FunctionalTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [FunctionalTest]
    [SuppressMessage("Usage", "xUnit1013", Justification = "Reviewed.")]
    public void FunctionalTest_without_parameters() { }
}
