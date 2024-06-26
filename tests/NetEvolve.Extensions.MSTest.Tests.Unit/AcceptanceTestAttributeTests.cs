﻿namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="AcceptanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class AcceptanceTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [AcceptanceTest]
    [DataRow(nameof(AcceptanceTest_without_parameters))]
    [DataRow(nameof(AcceptanceTest_without_or_invalid_parameters))]
    public async Task AcceptanceTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [AcceptanceTest]
    private void AcceptanceTest_without_parameters() => throw new NotSupportedException();
}
