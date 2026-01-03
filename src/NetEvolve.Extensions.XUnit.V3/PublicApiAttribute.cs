namespace NetEvolve.Extensions.XUnit.V3;

using System;
using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PublicApi</b>.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class PublicApiAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PublicApiAttribute"/> class.
    /// </summary>
    public PublicApiAttribute()
        : base(Internals.PublicApi) { }
}
