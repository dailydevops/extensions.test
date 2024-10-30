namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System.IO;
using System.Runtime.CompilerServices;
using VerifyNUnit;
using VerifyTests;

internal static class Predefined
{
    [ModuleInitializer]
    public static void Init()
    {
        Verifier.DerivePathInfo(
            (sourceFile, projectDirectory, type, method) =>
            {
                var directory = Path.Combine(
                    projectDirectory,
                    "..",
                    "_snapshots",
                    Namer.TargetFrameworkNameAndVersion
                );
                _ = Directory.CreateDirectory(directory);
                return new(directory, type.Name, method.Name);
            }
        );

        VerifierSettings.SortPropertiesAlphabetically();
        VerifierSettings.SortJsonObjects();
    }
}
