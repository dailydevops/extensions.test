﻿namespace NetEvolve.Extensions.TUnit.Tests.PublicApi;

using System.IO;
using System.Runtime.CompilerServices;
using VerifyTests;
using VerifyTUnit;

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
