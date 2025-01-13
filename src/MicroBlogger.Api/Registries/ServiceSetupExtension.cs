// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MicroBlogger.Api.Registries;

public static class ServiceSetupExtension
{
    public static void InstallConfigureInAssembly(this IServiceCollection app, IConfiguration configuration)
    {
        var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
          typeof(IServiceSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IServiceSetup>().ToList();

        installers.ForEach(installer => installer.InstallService(app, configuration));
    }
}
