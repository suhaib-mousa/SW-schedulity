using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.schedulity.Courses;
using SW.schedulity.Sections;
using System;
using System.Threading.Tasks;

namespace SW.schedulity.Web.Pages.Admin.Sections;
[Authorize]
public class SectioneModalModel : PageModel
{
    public ISectionAppService SectionAppService { get; }
    public SectioneModalModel(ISectionAppService sectionAppService)
    {
        SectionAppService = sectionAppService;
    }
    [BindProperty]
    public SectionDto Section { get; set; }
    public async Task OnGet()
    {
    }
    public async Task OnPost()
    {
        await SectionAppService.CreateAsync(Section);
    }
}
