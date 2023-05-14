using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SW.schedulity.Web.Pages;

[Authorize]
public class IndexModel : schedulityPageModel
{
    public IActionResult OnGet()
    {
        if (CurrentUser.IsInRole("admin"))
        {
            return Redirect("/Admin");
        }
        return Page();
    }
}
