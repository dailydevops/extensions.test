namespace NetEvolve.Extensions.TUnit.Tests.Unit;

public class SkipOnFailureAttributeTests
{
    [Test]
    [SkipOnFailure]
    public async Task Test_AlwaysFails_ShouldBeConvertedToSkipped()
    {
        // This test always fails to demonstrate that SkipOnFailureAttribute
        // converts the failure to a skipped state
        var alwaysFalse = 1 + 1 == 3;
        _ = await Assert.That(alwaysFalse).IsTrue();
    }

    [Test]
    [SkipOnFailure]
    public async Task Test_Succeeds_StaysSucceeded()
    {
        // This test always succeeds, to demonstrate that SkipOnFailureAttribute
        // does not affect the outcome of a passing test.
        var alwaysTrue = 1 + 1 == 2;
        _ = await Assert.That(alwaysTrue).IsTrue();
    }

    [Test]
    public async Task OnTestEnd_ContextIsNull_DoesNotThrow()
    {
        var attribute = new SkipOnFailureAttribute();

        await attribute.OnTestEnd(null!).ConfigureAwait(false);
    }
}
