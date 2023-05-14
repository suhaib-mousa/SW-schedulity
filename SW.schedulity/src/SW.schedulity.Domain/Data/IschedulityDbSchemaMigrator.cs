using System.Threading.Tasks;

namespace SW.schedulity.Data;

public interface IschedulityDbSchemaMigrator
{
    Task MigrateAsync();
}
