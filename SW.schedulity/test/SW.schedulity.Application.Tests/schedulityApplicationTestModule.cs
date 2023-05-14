using Volo.Abp.Modularity;

namespace SW.schedulity;

[DependsOn(
    typeof(schedulityApplicationModule),
    typeof(schedulityDomainTestModule)
    )]
public class schedulityApplicationTestModule : AbpModule
{

}
