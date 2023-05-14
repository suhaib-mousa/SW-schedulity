using SW.schedulity.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SW.schedulity.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(schedulityEntityFrameworkCoreModule),
    typeof(schedulityApplicationContractsModule)
    )]
public class schedulityDbMigratorModule : AbpModule
{

}
