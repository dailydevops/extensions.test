namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;
using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;

/// <summary>
/// Unit tests for <see cref="ContinuousTestBase"/>.
/// </summary>
/// <remarks>
/// <see cref="ContinuousTestBase"/> relies on the outcome of the previously executed test, which is tracked by NUnit
/// via <see cref="TestExecutionContext.CurrentContext"/>. To exercise this behavior without spinning up a nested
/// test run, the tests below temporarily swap the ambient <see cref="TestExecutionContext"/> for an isolated one and
/// simulate the previous test result directly.
/// </remarks>
[ExcludeFromCodeCoverage]
public class ContinuousTestBaseTests
{
    /// <summary>
    /// Tests that the setup does not disable the test execution, if the previous test succeeded.
    /// </summary>
    [Test]
    public async Task SetUpAsync_PreviousTestSucceeded_DoesNotDisableExecution()
    {
        using (new TestExecutionContext.IsolatedContext())
        {
            var context = TestExecutionContext.CurrentContext;
            SetPreviousResult(context, ResultState.Success);

            var sut = new TestFixture();

            Assert.DoesNotThrowAsync(() => sut.SetUpAsync());

            await sut.TearDownAsync();

            Assert.DoesNotThrowAsync(() => sut.SetUpAsync());
        }
    }

    /// <summary>
    /// Tests that a failing test disables the execution of all subsequent tests within the same fixture instance.
    /// </summary>
    [Test]
    public async Task TearDownAsync_PreviousTestFailed_DisablesSubsequentExecution()
    {
        using (new TestExecutionContext.IsolatedContext())
        {
            var context = TestExecutionContext.CurrentContext;
            SetPreviousResult(context, ResultState.Failure);

            var sut = new TestFixture();

            Assert.DoesNotThrowAsync(() => sut.SetUpAsync());

            await sut.TearDownAsync();

            _ = Assert.ThrowsAsync<InconclusiveException>(() => sut.SetUpAsync());
        }
    }

    /// <summary>
    /// Tests that the execution stays disabled for every following test, once it has been disabled.
    /// </summary>
    [Test]
    public async Task SetUpAsync_ExecutionAlreadyDisabled_StaysDisabled()
    {
        using (new TestExecutionContext.IsolatedContext())
        {
            var context = TestExecutionContext.CurrentContext;
            SetPreviousResult(context, ResultState.Failure);

            var sut = new TestFixture();

            await sut.TearDownAsync();

            _ = Assert.ThrowsAsync<InconclusiveException>(() => sut.SetUpAsync());

            SetPreviousResult(context, ResultState.Success);
            await sut.TearDownAsync();

            _ = Assert.ThrowsAsync<InconclusiveException>(() => sut.SetUpAsync());
        }
    }

    private static void SetPreviousResult(TestExecutionContext context, ResultState resultState)
    {
        var result = new TestCaseResult((TestMethod)context.CurrentTest);
        result.SetResult(resultState);
        context.CurrentResult = result;
    }

    private sealed class TestFixture : ContinuousTestBase;
}
