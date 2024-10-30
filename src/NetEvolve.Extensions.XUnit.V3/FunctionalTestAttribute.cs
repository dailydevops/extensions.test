namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>FunctionalTest</b>.
/// </summary>
public sealed class FunctionalTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FunctionalTestAttribute"/> class.
    /// </summary>
    public FunctionalTestAttribute()
        : base(Internals.FunctionalTest) { }
}
