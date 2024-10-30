namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>EndToEndTest</b>.
/// </summary>
public sealed class EndToEndTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndToEndTestAttribute"/> class.
    /// </summary>
    public EndToEndTestAttribute()
        : base(Internals.EndToEndTest) { }
}
