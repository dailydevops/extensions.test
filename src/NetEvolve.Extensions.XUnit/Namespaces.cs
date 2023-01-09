namespace NetEvolve.Extensions.XUnit;

/// <summary>
/// All internal namespaces
/// </summary>
internal static class Namespaces
{
    /// <summary>
    /// Assembly Name
    /// </summary>
#pragma warning disable IDE0002
    internal const string Assembly =
        $"{nameof(NetEvolve)}.{nameof(NetEvolve.Extensions)}.{nameof(NetEvolve.Extensions.XUnit)}";
#pragma warning restore IDE0002

    /// <summary>
    /// Full qualified name for <see cref="Internal.CategoryTraitDiscoverer"/>
    /// </summary>
#pragma warning disable IDE0002
    internal const string CategoryTraitDiscoverer =
        $"{Assembly}.{nameof(NetEvolve.Extensions.XUnit.Internal)}.{nameof(NetEvolve.Extensions.XUnit.Internal.CategoryTraitDiscoverer)}";
#pragma warning restore IDE0002

    /// <summary>
    /// Full qualified name for <see cref="Internal.CultureTraitDiscoverer"/>
    /// </summary>
#pragma warning disable IDE0002
    internal const string CultureTraitDiscoverer =
        $"{Assembly}.{nameof(NetEvolve.Extensions.XUnit.Internal)}.{nameof(NetEvolve.Extensions.XUnit.Internal.CultureTraitDiscoverer)}";
#pragma warning restore IDE0002
}
