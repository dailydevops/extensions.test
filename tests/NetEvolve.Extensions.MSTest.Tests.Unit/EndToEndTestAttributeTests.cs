namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="EndToEndTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class EndToEndTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [EndToEndTest]
    [DataRow(nameof(EndToEndTest_without_parameters))]
    [DataRow(nameof(EndToEndTest_without_or_invalid_parameters))]
    public async Task EndToEndTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [EndToEndTest]
    private void EndToEndTest_without_parameters() => throw new NotSupportedException();
}
