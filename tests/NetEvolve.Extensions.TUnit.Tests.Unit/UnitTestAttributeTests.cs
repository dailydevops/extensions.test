namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="UnitTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class UnitTestAttributeTests : AttributeTestsBase
{
    [Test]
    [UnitTest]
    [Arguments(nameof(UnitTest_without_parameters))]
    [Arguments(nameof(UnitTest_without_or_invalid_parameters))]
    public async Task UnitTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [UnitTest]
    protected void UnitTest_without_parameters() => throw new NotSupportedException();
}
