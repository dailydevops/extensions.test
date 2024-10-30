namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>ArchitectureTest</b>.
/// </summary>
public sealed class ArchitectureTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArchitectureTestAttribute"/> class.
    /// </summary>
    public ArchitectureTestAttribute()
        : base(Internals.ArchitectureTest) { }
}
