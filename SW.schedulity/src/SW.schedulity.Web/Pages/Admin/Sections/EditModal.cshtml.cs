using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.schedulity.Courses;
using SW.schedulity.Sections;
using System;
using System.Threading.Tasks;

namespace SW.schedulity.Web.Pages.Admin.Sections;
[Authorize]
public class EditModalModel : PageModel
{
    public ISectionAppService SectionAppService { get; }
    public EditModalModel(ISectionAppService sectionAppService)
    {
        SectionAppService = sectionAppService;
    }
    [BindProperty]
    public SectionDto Section { get; set; }
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    public async Task OnGet()
    {
        Section = await SectionAppService.GetAsync(Id);
    }
    public async Task OnPost()
    {
        await SectionAppService.UpdateAsync(Id, Section);
    }
}
