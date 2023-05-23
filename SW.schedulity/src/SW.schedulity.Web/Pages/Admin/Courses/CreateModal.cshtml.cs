using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.schedulity.Courses;
using SW.schedulity.Sections;
using System;
using System.Threading.Tasks;

namespace SW.schedulity.Web.Pages.Admin.Courses;
[Authorize]
public class CreateModalModel : PageModel
{
    public CreateModalModel(ICourseAppService courseAppService, ISectionAppService sectionAppService)
    {
        CourseAppService = courseAppService;
        SectionAppService = sectionAppService;
    }
    [BindProperty]
    public CourseDto Course { get; set; } = new CourseDto();
    [BindProperty(SupportsGet = true)]
    public Guid SectionId { get; set; }
    public ICourseAppService CourseAppService { get; }
    public ISectionAppService SectionAppService { get; }

    public async Task OnGet()
    {
    }
    public async Task OnPost()
    {
        var x = Course.SectionId;
        await CourseAppService.CreateAsync(Course);
    }
}
