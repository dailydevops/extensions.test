﻿namespace NetEvolve.Extensions.MSTest;

using System;
using NetEvolve.Extensions.MSTest.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>ArchitectureTest</b>.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class ArchitectureTestAttribute : TestTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArchitectureTestAttribute"/> class.
    /// </summary>
    public ArchitectureTestAttribute()
        : base(Internals.ArchitectureTest) { }
}
