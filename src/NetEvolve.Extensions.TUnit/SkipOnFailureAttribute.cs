namespace NetEvolve.Extensions.TUnit;

using System;
using System.Threading.Tasks;
using global::TUnit.Core;
using global::TUnit.Core.Enums;
using global::TUnit.Core.Interfaces;

/// <summary>
/// Marks a test as flaky. Tests marked with this attribute will be automatically skipped
/// when they fail, since their nature is inherently unreliable.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class SkipOnFailureAttribute : Attribute, ITestEndEventReceiver
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SkipOnFailureAttribute"/> class.
    /// </summary>
    public SkipOnFailureAttribute() { }

    /// <inheritdoc />
    public int Order => int.MaxValue;

    /// <inheritdoc />
    public ValueTask OnTestEnd(TestContext context)
    {
        // If the test failed, convert it to a skipped state
        if (context?.Execution.Result?.State == TestState.Failed)
        {
            context.Execution.OverrideResult(
                TestState.Skipped,
                "Test marked as flaky and failed - automatically skipped"
            );
        }

        return new ValueTask();
    }
}
