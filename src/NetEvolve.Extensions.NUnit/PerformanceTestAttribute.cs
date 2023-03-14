namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as PerformanceTest.
/// </summary>
public sealed class PerformanceTestAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PerformanceTestAttribute"/> class.
    /// </summary>
    public PerformanceTestAttribute()
        : base(Internals.PerformanceTest) { }
}
