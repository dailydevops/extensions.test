namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as FunctionalTest.
/// </summary>
public sealed class FunctionalTestAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FunctionalTestAttribute"/> class.
    /// </summary>
    public FunctionalTestAttribute()
        : base(Internals.FunctionalTest) { }
}
