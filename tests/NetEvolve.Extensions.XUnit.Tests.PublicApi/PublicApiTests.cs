﻿namespace NetEvolve.Extensions.XUnit.Tests.PublicApi;

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using PublicApiGenerator;
using Xunit;

public class PublicApiTests
{
    [Fact]
    [TestGroup("PublicApi")]
    public Task PublicApi_HasNotChanged_Expected()
    {
        var assembly = typeof(AcceptanceTestAttribute).Assembly;
        var types = assembly.GetTypes().Where(IsVisibleToIntelliSense).ToArray();

        var options = new ApiGeneratorOptions
        {
            ExcludeAttributes =
            [
                typeof(InternalsVisibleToAttribute).FullName!,
                "System.Runtime.CompilerServices.IsByRefLikeAttribute",
                typeof(TargetFrameworkAttribute).FullName!,
                typeof(CLSCompliantAttribute).FullName!,
                typeof(AssemblyMetadataAttribute).FullName!,
                typeof(NeutralResourcesLanguageAttribute).FullName!,
                typeof(AttributeUsageAttribute).FullName!,
            ],
            IncludeTypes = types,
        };

        var publicApi = assembly.GeneratePublicApi(options);

        return Verify(publicApi);
    }

    private static bool IsVisibleToIntelliSense(Type type)
    {
        var browsable = type.GetCustomAttribute<BrowsableAttribute>();
        if (browsable?.Browsable != false)
        {
            return true;
        }

        var editorBrowsable = type.GetCustomAttribute<EditorBrowsableAttribute>();
        return editorBrowsable is null || editorBrowsable.State != EditorBrowsableState.Never;
    }
}
