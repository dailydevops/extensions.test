namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>IntegrationTest</b>.
/// </summary>
public sealed class IntegrationTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationTestAttribute"/> class.
    /// </summary>
    public IntegrationTestAttribute()
        : base(Internals.IntegrationTest) { }
}
