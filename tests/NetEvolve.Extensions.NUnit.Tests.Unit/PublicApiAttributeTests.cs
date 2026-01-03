namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="PublicApiAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PublicApiAttributeTests : AttributeTestsBase
{
    [Theory]
    [PublicApi]
    [TestCase(nameof(PublicApi_without_parameters))]
    [TestCase(nameof(PublicApi_without_or_invalid_parameters))]
    public async Task PublicApi_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [PublicApi]
    private void PublicApi_without_parameters() => throw new NotSupportedException();
}
