namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="CodedUITestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class CodedUITestAttributeTests : AttributeTestsBase
{
    [Theory]
    [CodedUITest]
    [TestCase(nameof(CodedUITest_without_parameters))]
    [TestCase(nameof(CodedUITest_without_or_invalid_parameters))]
    public async Task CodedUITest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [CodedUITest]
    private void CodedUITest_without_parameters() => throw new NotSupportedException();
}
