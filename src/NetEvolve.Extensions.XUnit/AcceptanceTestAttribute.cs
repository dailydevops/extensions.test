namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <see cref="AcceptanceTestAttribute"/>
/// </summary>
public sealed class AcceptanceTestAttribute : CategoryTraitAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptanceTestAttribute"/> class.
    /// </summary>
    public AcceptanceTestAttribute() : base(Internals.AcceptanceTest) { }
}
