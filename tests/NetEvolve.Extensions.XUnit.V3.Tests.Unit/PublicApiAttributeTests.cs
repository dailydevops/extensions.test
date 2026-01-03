namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="PublicApiAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PublicApiAttributeTests : AttributeTestsBase
{
    [Theory]
    [PublicApi]
    [InlineData(nameof(PublicApi_without_parameters))]
    [InlineData(nameof(PublicApi_without_or_invalid_parameters))]
    public async Task PublicApi_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [PublicApi]
    protected void PublicApi_without_parameters() => throw new NotSupportedException();
}
