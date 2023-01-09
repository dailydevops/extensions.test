namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as IntegrationTest
/// </summary>
public sealed class IntegrationTestAttribute : CategoryTraitAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationTestAttribute"/> class.
    /// </summary>
    public IntegrationTestAttribute() : base(Internals.IntegrationTest) { }
}
