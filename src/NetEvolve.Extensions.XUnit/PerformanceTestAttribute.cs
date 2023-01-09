namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as PerformanceTest
/// </summary>
public sealed class PerformanceTestAttribute : CategoryTraitAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PerformanceTestAttribute"/> class.
    /// </summary>
    public PerformanceTestAttribute() : base(Internals.PerformanceTest) { }
}
