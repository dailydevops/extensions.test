namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>CodedUITest</b>.
/// </summary>
public sealed class CodedUITestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodedUITestAttribute"/> class.
    /// </summary>
    public CodedUITestAttribute()
        : base(Internals.CodedUITest) { }
}
