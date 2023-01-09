namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="PreDeploymentAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PreDeploymentAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="PreDeploymentAttribute"/>.
    /// </summary>
    [Test]
    [PreDeployment]
    public async Task PreDeployment_Expected()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }
}
