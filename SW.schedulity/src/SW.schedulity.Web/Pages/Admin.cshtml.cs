using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace SW.schedulity.Web.Pages
{
    [Authorize(Roles ="admin")]
    public class AdminModel : PageModel
    {
        public AdminModel(IIdentityUserAppService identityUserAppService)
        {
            IdentityUserAppService = identityUserAppService;
        }

        public IIdentityUserAppService IdentityUserAppService { get; }
        public long UsersCount { get; private set; }

        public async Task OnGet()
        {
            UsersCount = (await IdentityUserAppService.GetListAsync(new() { })).TotalCount;
        }
    }
}
