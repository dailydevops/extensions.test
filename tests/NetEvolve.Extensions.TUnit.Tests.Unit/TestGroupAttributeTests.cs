namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="TestGroupAttribute"/>.
/// </summary>
/// <remarks>
/// The "TestGroup" trait itself is already exercised assembly-wide, via the <c>[TestGroup("TUnit")]</c> assembly
/// attribute declared in the project file; these tests only cover the defensive branch of
/// <see cref="Internal.NamedCategoryTraitBaseAttribute.OnTestDiscovered"/>.
/// </remarks>
[ExcludeFromCodeCoverage]
public class TestGroupAttributeTests
{
    /// <summary>
    /// Tests that <see cref="Internal.NamedCategoryTraitBaseAttribute.OnTestDiscovered"/> is a no-op, when invoked with a <see langword="null"/> context.
    /// </summary>
    [Test]
    public async Task OnTestDiscovered_ContextIsNull_DoesNotThrow()
    {
        var attribute = new TestGroupAttribute("MyGroup");

        await attribute.OnTestDiscovered(null!).ConfigureAwait(false);
    }
}
