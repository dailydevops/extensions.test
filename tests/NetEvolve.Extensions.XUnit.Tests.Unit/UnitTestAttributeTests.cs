namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

/// <summary>
/// Unit tests for <see cref="UnitTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class UnitTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [UnitTest]
    [InlineData(nameof(UnitTest_without_parameters))]
    [InlineData(nameof(UnitTest_without_or_invalid_parameters))]
    public async Task UnitTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [UnitTest]
    [SuppressMessage("Usage", "xUnit1013", Justification = "Reviewed.")]
    public void UnitTest_without_parameters() { }
}
