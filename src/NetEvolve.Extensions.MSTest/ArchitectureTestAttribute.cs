namespace NetEvolve.Extensions.MSTest;

using NetEvolve.Extensions.MSTest.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>ArchitectureTest</b>.
/// </summary>
public sealed class ArchitectureTestAttribute : TestTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArchitectureTestAttribute"/> class.
    /// </summary>
    public ArchitectureTestAttribute()
        : base(Internals.ArchitectureTest) { }
}
