﻿namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="PerformanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class PerformanceTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [PerformanceTest]
    [DataRow(nameof(PerformanceTest_without_parameters))]
    [DataRow(nameof(PerformanceTest_without_or_invalid_parameters))]
    public async Task PerformanceTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [PerformanceTest]
    public void PerformanceTest_without_parameters() { }
}