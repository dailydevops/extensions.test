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
}
