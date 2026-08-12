namespace NetEvolve.Extensions.TUnit.Tests.Unit.Logging;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::Microsoft.Extensions.Logging;
using NetEvolve.Extensions.TUnit.Logging;
using TUnitLogLevel = global::TUnit.Core.Logging.LogLevel;

/// <summary>
/// Unit tests for <see cref="TUnitLogger"/>, <see cref="TUnitLogger{T}"/> and <see cref="TUnitLoggerExtensions"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class TUnitLoggerTests
{
    [Test]
    [Arguments(LogLevel.Trace, TUnitLogLevel.Trace)]
    [Arguments(LogLevel.Debug, TUnitLogLevel.Debug)]
    [Arguments(LogLevel.Information, TUnitLogLevel.Information)]
    [Arguments(LogLevel.Warning, TUnitLogLevel.Warning)]
    [Arguments(LogLevel.Error, TUnitLogLevel.Error)]
    [Arguments(LogLevel.Critical, TUnitLogLevel.Critical)]
    [Arguments(LogLevel.None, TUnitLogLevel.None)]
    public async Task IsEnabled_ConvertsLogLevel_UsesUnderlyingLogger(LogLevel logLevel, TUnitLogLevel expected)
    {
        var innerLogger = new FakeTUnitLogger(expected, isEnabled: true);
        var logger = innerLogger.ConvertTo();

        var result = logger.IsEnabled(logLevel);

        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(innerLogger.LastIsEnabledLevel).IsEqualTo(expected);
    }

    [Test]
    public async Task Log_DelegatesToUnderlyingLogger_WithConvertedLevelAndFormattedMessage()
    {
        var innerLogger = new FakeTUnitLogger(TUnitLogLevel.Information, isEnabled: true);
        var logger = innerLogger.ConvertTo();
        var exception = new InvalidOperationException("boom");

        logger.Log(LogLevel.Information, new EventId(1), "state", exception, (state, ex) => $"{state}-{ex?.Message}");

        _ = await Assert.That(innerLogger.LastLogLevel).IsEqualTo(TUnitLogLevel.Information);
        _ = await Assert.That(innerLogger.LastMessage).IsEqualTo("state-boom");
    }

    [Test]
    public async Task BeginScope_ReturnsSharedNullScopeInstance()
    {
        var logger = new FakeTUnitLogger(TUnitLogLevel.Information, isEnabled: true).ConvertTo();

        using var scopeA = logger.BeginScope("scope-a");
        using var scopeB = logger.BeginScope("scope-b");

        _ = await Assert.That(scopeA).IsSameReferenceAs(scopeB);

        scopeA?.Dispose();
    }

    [Test]
    public async Task ConvertTo_Generic_CreatesTypedLogger()
    {
        var logger = new FakeTUnitLogger(TUnitLogLevel.Information, isEnabled: true).ConvertTo<TUnitLoggerTests>();

        _ = await Assert.That(logger).IsNotNull();
        _ = await Assert.That(logger.IsEnabled(LogLevel.Information)).IsTrue();
    }

    private sealed class FakeTUnitLogger(TUnitLogLevel enabledLevel, bool isEnabled)
        : global::TUnit.Core.Logging.ILogger
    {
        public TUnitLogLevel? LastIsEnabledLevel { get; private set; }

        public TUnitLogLevel? LastLogLevel { get; private set; }

        public string? LastMessage { get; private set; }

        public bool IsEnabled(TUnitLogLevel logLevel)
        {
            LastIsEnabledLevel = logLevel;
            return isEnabled && logLevel == enabledLevel;
        }

        public void Log<TState>(
            TUnitLogLevel logLevel,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter
        )
        {
            LastLogLevel = logLevel;
            LastMessage = formatter(state, exception);
        }

        public ValueTask LogAsync<TState>(
            TUnitLogLevel logLevel,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter
        )
        {
            Log(logLevel, state, exception, formatter);
            return new ValueTask();
        }
    }
}
