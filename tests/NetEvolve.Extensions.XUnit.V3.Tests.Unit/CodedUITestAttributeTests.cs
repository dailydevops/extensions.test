namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="CodedUITestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class CodedUITestAttributeTests : AttributeTestsBase
{
    [Theory]
    [CodedUITest]
    [InlineData(nameof(CodedUITest_without_parameters))]
    [InlineData(nameof(CodedUITest_without_or_invalid_parameters))]
    public async Task CodedUITest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [CodedUITest]
    protected void CodedUITest_without_parameters() => throw new NotSupportedException();
}
