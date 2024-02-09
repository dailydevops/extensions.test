namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="UnitTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class UnitTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [UnitTest]
    [InlineData(nameof(UnitTest_without_parameters))]
    [InlineData(nameof(UnitTest_without_or_invalid_parameters))]
    public async Task UnitTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [UnitTest]
    protected void UnitTest_without_parameters() => throw new NotSupportedException();
}
