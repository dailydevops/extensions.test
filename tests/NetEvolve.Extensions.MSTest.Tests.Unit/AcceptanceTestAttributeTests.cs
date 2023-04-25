namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="AcceptanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
[AcceptanceTest]
public class AcceptanceTestAttributeTests
{
    [TestMethod]
    [DataRow(nameof(AcceptanceTest_without_parameters))]
    public async Task AcceptanceTest_without_or_invalid_parameters(string methodName)
    {
        await Task.Yield();
        await Task.Yield();
        Assert.IsTrue(true);
    }

    public void AcceptanceTest_without_parameters() { }
}
