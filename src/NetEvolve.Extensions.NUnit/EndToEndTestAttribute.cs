namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>EndToEndTest</b>.
/// </summary>
public sealed class EndToEndTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndToEndTestAttribute"/> class.
    /// </summary>
    public EndToEndTestAttribute()
        : base(Internals.EndToEndTest) { }
}
