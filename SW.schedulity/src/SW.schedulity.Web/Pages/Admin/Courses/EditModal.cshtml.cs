using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.schedulity.Courses;
using SW.schedulity.Sections;
using System;
using System.Threading.Tasks;

namespace SW.schedulity.Web.Pages.Admin.Courses;
[Authorize]
public class EditModalModel : PageModel
{
    public ICourseAppService CourseAppService { get; }
    public EditModalModel(ICourseAppService courseAppService)
    {
        CourseAppService = courseAppService;
    }
    [BindProperty]
    public CourseDto Course { get; set; }
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    public async Task OnGet()
    {
        Course = await CourseAppService.GetAsync(Id);
    }
    public async Task OnPost()
    {
        await CourseAppService.UpdateAsync(Id, Course);
    }
}
