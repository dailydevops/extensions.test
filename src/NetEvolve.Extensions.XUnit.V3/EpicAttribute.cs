namespace NetEvolve.Extensions.XUnit.V3;

using System;
using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>Epic</b>, with optional Id
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class EpicAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EpicAttribute"/> class.
    /// </summary>
    public EpicAttribute()
        : base(Internals.Epic, null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpicAttribute"/> class.
    /// </summary>
    /// <param name="id">Bug Id</param>
    public EpicAttribute(string? id)
        : base(Internals.Epic, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpicAttribute"/> class.
    /// </summary>
    /// <param name="id">Bug Id</param>
    public EpicAttribute(long id)
        : base(Internals.Epic, id) { }
}
