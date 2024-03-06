namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PerformanceTest</b>.
/// </summary>
public sealed class PerformanceTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PerformanceTestAttribute"/> class.
    /// </summary>
    public PerformanceTestAttribute()
        : base(Internals.PerformanceTest) { }
}
