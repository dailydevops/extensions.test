namespace NetEvolve.Extensions.TUnit.Logging;

using Microsoft.Extensions.Logging;

/// <summary>
/// Provides extension methods for converting <see cref="global::TUnit.Core.Logging.ILogger"/> instances
/// to Microsoft.Extensions.Logging <see cref="ILogger"/> and <see cref="ILogger{T}"/> instances.
/// </summary>
public static class TUnitLoggerExtensions
{
    /// <summary>
    /// Converts a TUnit <see cref="global::TUnit.Core.Logging.ILogger"/> to a Microsoft.Extensions.Logging <see cref="ILogger"/>.
    /// </summary>
    /// <param name="logger">The TUnit logger instance to convert.</param>
    /// <returns>An <see cref="ILogger"/> implementation that wraps the provided TUnit logger.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="logger"/> is <see langword="null"/>.</exception>
    public static ILogger ConvertTo(this global::TUnit.Core.Logging.ILogger logger) => new TUnitLogger(logger);

    /// <summary>
    /// Converts a TUnit <see cref="global::TUnit.Core.Logging.ILogger"/> to a Microsoft.Extensions.Logging <see cref="ILogger{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type associated with the logger, typically used for categorization.</typeparam>
    /// <param name="logger">The TUnit logger instance to convert.</param>
    /// <returns>An <see cref="ILogger{T}"/> implementation that wraps the provided TUnit logger.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="logger"/> is <see langword="null"/>.</exception>
    public static ILogger<T> ConvertTo<T>(this global::TUnit.Core.Logging.ILogger logger) => new TUnitLogger<T>(logger);
}
