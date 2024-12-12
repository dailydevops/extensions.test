namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="PostDeploymentAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PostDeploymentAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="PostDeploymentAttribute"/>.
    /// </summary>
    [Test]
    [PostDeployment]
    public async Task PostDeployment_Expected()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
