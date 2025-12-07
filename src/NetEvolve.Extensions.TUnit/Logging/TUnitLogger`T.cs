namespace NetEvolve.Extensions.TUnit.Logging;

using Microsoft.Extensions.Logging;

internal sealed class TUnitLogger<T> : TUnitLogger, ILogger<T>
{
    public TUnitLogger(global::TUnit.Core.Logging.ILogger logger)
        : base(logger) { }
}
