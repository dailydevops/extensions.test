namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>AcceptanceTest</b>.
/// </summary>
public sealed class AcceptanceTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptanceTestAttribute"/> class.
    /// </summary>
    public AcceptanceTestAttribute()
        : base(Internals.AcceptanceTest) { }
}
