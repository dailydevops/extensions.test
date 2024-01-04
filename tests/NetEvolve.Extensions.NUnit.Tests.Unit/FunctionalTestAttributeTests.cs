namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="FunctionalTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class FunctionalTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [FunctionalTest]
    [TestCase(nameof(FunctionalTest_without_parameters))]
    [TestCase(nameof(FunctionalTest_without_or_invalid_parameters))]
    public async Task FunctionalTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [FunctionalTest]
    private void FunctionalTest_without_parameters() => throw new NotSupportedException();
}
