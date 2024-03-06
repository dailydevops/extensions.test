namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PerformanceTest</b>.
/// </summary>
public sealed class PerformanceTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PerformanceTestAttribute"/> class.
    /// </summary>
    public PerformanceTestAttribute()
        : base(Internals.PerformanceTest) { }
}
