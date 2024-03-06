namespace NetEvolve.Extensions.MSTest;

using NetEvolve.Extensions.MSTest.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>UnitTest</b>.
/// </summary>
public sealed class UnitTestAttribute : TestTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class.
    /// </summary>
    public UnitTestAttribute()
        : base(Internals.UnitTest) { }
}
