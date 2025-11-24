namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System.Security.Cryptography;

public class SkipOnFailureAttributeTests
{
    private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

    [Test]
    [SkipOnFailure]
    public async Task Test_WithFlakySometimesFailingBehavior()
    {
        var bytes = new byte[1];
        _rng.GetBytes(bytes);
        var result = bytes[0] % 2; // Generates 0 or 1

        _ = await Assert.That(result).IsEqualTo(1);
    }
}
