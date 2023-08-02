namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

/// <summary>
/// Unit tests for <see cref="PreDeploymentAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class PreDeploymentAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="PreDeploymentAttribute"/>.
    /// </summary>
    [Fact]
    [PreDeployment]
    public async Task PreDeployment_Expected()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
