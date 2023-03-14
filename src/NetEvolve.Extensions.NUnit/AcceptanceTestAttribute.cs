namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as AcceptanceTest.
/// </summary>
public sealed class AcceptanceTestAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptanceTestAttribute"/> class.
    /// </summary>
    public AcceptanceTestAttribute()
        : base(Internals.AcceptanceTest) { }
}
