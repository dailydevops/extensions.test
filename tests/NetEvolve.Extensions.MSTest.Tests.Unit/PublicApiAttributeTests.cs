namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="PublicApiAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class PublicApiAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [PublicApi]
    [DataRow(nameof(PublicApi_without_parameters))]
    [DataRow(nameof(PublicApi_without_or_invalid_parameters))]
    public async Task PublicApi_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [PublicApi]
    private void PublicApi_without_parameters() => throw new NotSupportedException();
}
