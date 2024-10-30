namespace NetEvolve.Extensions.XUnit;

using System;
using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>CodedUITest</b>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class CodedUITestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodedUITestAttribute"/> class.
    /// </summary>
    public CodedUITestAttribute()
        : base(Internals.CodedUITest) { }
}
