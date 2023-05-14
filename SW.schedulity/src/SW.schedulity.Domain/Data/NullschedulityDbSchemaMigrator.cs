using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SW.schedulity.Data;

/* This is used if database provider does't define
 * IschedulityDbSchemaMigrator implementation.
 */
public class NullschedulityDbSchemaMigrator : IschedulityDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
