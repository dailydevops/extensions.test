namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>FunctionalTest</b>.
/// </summary>
public sealed class FunctionalTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FunctionalTestAttribute"/> class.
    /// </summary>
    public FunctionalTestAttribute()
        : base(Internals.FunctionalTest) { }
}
