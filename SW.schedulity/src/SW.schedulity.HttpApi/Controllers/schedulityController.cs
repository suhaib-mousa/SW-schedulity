using SW.schedulity.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SW.schedulity.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class schedulityController : AbpControllerBase
{
    protected schedulityController()
    {
        LocalizationResource = typeof(schedulityResource);
    }
}
