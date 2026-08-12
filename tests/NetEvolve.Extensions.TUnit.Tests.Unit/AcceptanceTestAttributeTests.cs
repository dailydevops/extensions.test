namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="AcceptanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class AcceptanceTestAttributeTests : AttributeTestsBase
{
    [Test]
    [AcceptanceTest]
    [Arguments(nameof(AcceptanceTest_without_parameters))]
    [Arguments(nameof(AcceptanceTest_without_or_invalid_parameters))]
    public async Task AcceptanceTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName).ConfigureAwait(false);
    }

    [AcceptanceTest]
    protected void AcceptanceTest_without_parameters() => throw new NotSupportedException();

    /// <summary>
    /// Tests that <see cref="Internal.CategoryTraitBaseAttribute.OnTestDiscovered"/> is a no-op, when invoked with a <see langword="null"/> context.
    /// </summary>
    [Test]
    public async Task OnTestDiscovered_ContextIsNull_DoesNotThrow()
    {
        var attribute = new AcceptanceTestAttribute();

        await attribute.OnTestDiscovered(null!).ConfigureAwait(false);
    }
}
