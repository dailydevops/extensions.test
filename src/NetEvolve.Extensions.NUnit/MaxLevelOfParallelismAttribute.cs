namespace NetEvolve.Extensions.NUnit;

using System;
using System.Diagnostics.CodeAnalysis;
using global::NUnit.Framework;

/// <summary>
/// Sets the number of worker threads taking into account the available
/// <see cref="Environment.ProcessorCount"/> that can be allocated by the framework
/// for the execution of tests.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
[SuppressMessage(
    "Design",
    "CA1019:Define accessors for attribute arguments",
    Justification = "As designed."
)]
public sealed class MaxLevelOfParallelismAttribute : PropertyAttribute
{
    /// <summary>
    /// Construct a <see cref="MaxLevelOfParallelismAttribute"/>.
    /// </summary>
    /// <param name="level">The number of worker threads to be created by the framework.</param>
    public MaxLevelOfParallelismAttribute(int level)
        : this(level, Environment.ProcessorCount - 1) { }

    /// <summary>
    /// Construct a <see cref="MaxLevelOfParallelismAttribute"/>.
    /// </summary>
    /// <param name="level">The number of worker threads to be created by the framework.</param>
    /// <param name="alternativeLevel">The number of workers, which should be used alternatively.</param>
    public MaxLevelOfParallelismAttribute(int level, int alternativeLevel)
        : base("LevelOfParallelism", Math.Min(level, alternativeLevel)) { }
}
