using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SW.schedulity.Data;
using Volo.Abp.DependencyInjection;

namespace SW.schedulity.EntityFrameworkCore;

public class EntityFrameworkCoreschedulityDbSchemaMigrator
    : IschedulityDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreschedulityDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the schedulityDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<schedulityDbContext>()
            .Database
            .MigrateAsync();
    }
}
