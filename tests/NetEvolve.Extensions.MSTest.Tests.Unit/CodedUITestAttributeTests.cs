namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="CodedUITestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class CodedUITestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [CodedUITest]
    [DataRow(nameof(CodedUITest_without_parameters))]
    [DataRow(nameof(CodedUITest_without_or_invalid_parameters))]
    public async Task CodedUITest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [CodedUITest]
    private void CodedUITest_without_parameters() => throw new NotSupportedException();
}
