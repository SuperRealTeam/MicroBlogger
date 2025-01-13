// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MicroBlogger.Api.Workers;

namespace MicroBlogger.Api.Registries;

public class BackgroundServiceInstall : IServiceSetup
{
    public void InstallService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("WebpFileConversion"))
            serviceCollection.AddSingleton<IHostedService, WebpFileConversionHostService>();
    }
}
