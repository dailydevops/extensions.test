﻿namespace NetEvolve.Extensions.NUnit;

using System;
using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>Epic</b>, with optional Id.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class EpicAttribute : CategoryIdBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EpicAttribute"/> class.
    /// </summary>
    public EpicAttribute()
        : base(Internals.Epic) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpicAttribute"/> class.
    /// </summary>
    /// <param name="id">Epic Id</param>
    public EpicAttribute(string? id)
        : base(Internals.Epic, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpicAttribute"/> class.
    /// </summary>
    /// <param name="id">Epic Id</param>
    public EpicAttribute(long id)
        : base(Internals.Epic, $"{id}") { }
}
