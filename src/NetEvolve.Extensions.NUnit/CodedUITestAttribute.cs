namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>CodedUITest</b>.
/// </summary>
public sealed class CodedUITestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodedUITestAttribute"/> class.
    /// </summary>
    public CodedUITestAttribute()
        : base(Internals.CodedUITest) { }
}
