namespace NetEvolve.Extensions.TUnit.Logging;

using System;

/// <summary>
/// An empty scope without any logic
/// </summary>
internal sealed class TUnitNullScope : IDisposable
{
    public static TUnitNullScope Instance { get; } = new TUnitNullScope();

    private TUnitNullScope() { }

    /// <inheritdoc />
    public void Dispose() { }
}
