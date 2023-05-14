using SW.schedulity.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SW.schedulity.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class schedulityPageModel : AbpPageModel
{
    protected schedulityPageModel()
    {
        LocalizationResourceType = typeof(schedulityResource);
    }
}
