namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="UnitTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class UnitTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [UnitTest]
    [DataRow(nameof(UnitTest_without_parameters))]
    [DataRow(nameof(UnitTest_without_or_invalid_parameters))]
    public async Task UnitTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [UnitTest]
    private void UnitTest_without_parameters() => throw new NotSupportedException();
}
