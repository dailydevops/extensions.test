namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="FunctionalTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class FunctionalTestAttributeTests : AttributeTestsBase
{
    [Test]
    [FunctionalTest]
    [Arguments(nameof(FunctionalTest_without_parameters))]
    [Arguments(nameof(FunctionalTest_without_or_invalid_parameters))]
    public async Task FunctionalTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [FunctionalTest]
    protected void FunctionalTest_without_parameters() => throw new NotSupportedException();
}
