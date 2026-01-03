namespace NetEvolve.Extensions.NUnit;

using System;
using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PublicApi</b>.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class PublicApiAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PublicApiAttribute"/> class.
    /// </summary>
    public PublicApiAttribute()
        : base(Internals.PublicApi) { }
}
