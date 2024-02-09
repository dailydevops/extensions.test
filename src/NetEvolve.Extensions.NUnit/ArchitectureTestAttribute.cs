namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as UnitTest.
/// </summary>
public sealed class ArchitectureTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArchitectureTestAttribute"/> class.
    /// </summary>
    public ArchitectureTestAttribute()
        : base(Internals.ArchitectureTest) { }
}
