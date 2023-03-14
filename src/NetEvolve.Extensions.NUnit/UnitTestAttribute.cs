namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as UnitTest.
/// </summary>
public sealed class UnitTestAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class.
    /// </summary>
    public UnitTestAttribute()
        : base(Internals.UnitTest) { }
}
