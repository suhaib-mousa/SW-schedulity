using SW.schedulity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SW.schedulity;

[DependsOn(
    typeof(schedulityEntityFrameworkCoreTestModule)
    )]
public class schedulityDomainTestModule : AbpModule
{

}
