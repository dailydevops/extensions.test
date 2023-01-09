namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="PostDeploymentAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class PostDeploymentAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="PostDeploymentAttribute"/>.
    /// </summary>
    [Fact]
    [PostDeployment]
    public async Task PostDeployment_Expected()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
