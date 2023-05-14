using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace SW.schedulity;

public class schedulityWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<schedulityWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
