namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="ArchitectureTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class ArchitectureTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [ArchitectureTest]
    [DataRow(nameof(ArchitectureTest_without_parameters))]
    [DataRow(nameof(ArchitectureTest_without_or_invalid_parameters))]
    public async Task ArchitectureTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [ArchitectureTest]
    private void ArchitectureTest_without_parameters() => throw new NotSupportedException();
}
