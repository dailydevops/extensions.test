namespace NetEvolve.Extensions.TUnit.Logging;

using System;
using Microsoft.Extensions.Logging;

internal class TUnitLogger : ILogger
{
    private readonly global::TUnit.Core.Logging.ILogger _logger;

    public TUnitLogger(global::TUnit.Core.Logging.ILogger logger) => _logger = logger;

    public IDisposable? BeginScope<TState>(TState state)
        where TState : notnull => TUnitNullScope.Instance;

    public bool IsEnabled(LogLevel logLevel) => _logger.IsEnabled(ConvertLogLevel(logLevel));

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter
    ) => _logger.Log(ConvertLogLevel(logLevel), state, exception, formatter);

    private static global::TUnit.Core.Logging.LogLevel ConvertLogLevel(LogLevel logLevel) =>
        logLevel switch
        {
            LogLevel.Trace => global::TUnit.Core.Logging.LogLevel.Trace,
            LogLevel.Debug => global::TUnit.Core.Logging.LogLevel.Debug,
            LogLevel.Information => global::TUnit.Core.Logging.LogLevel.Information,
            LogLevel.Warning => global::TUnit.Core.Logging.LogLevel.Warning,
            LogLevel.Error => global::TUnit.Core.Logging.LogLevel.Error,
            LogLevel.Critical => global::TUnit.Core.Logging.LogLevel.Critical,
            _ => global::TUnit.Core.Logging.LogLevel.None,
        };
}
