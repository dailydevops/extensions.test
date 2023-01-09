namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as EndToEndTest.
/// </summary>
public sealed class EndToEndTestAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndToEndTestAttribute"/> class.
    /// </summary>
    public EndToEndTestAttribute() : base(Internals.EndToEndTest) { }
}
