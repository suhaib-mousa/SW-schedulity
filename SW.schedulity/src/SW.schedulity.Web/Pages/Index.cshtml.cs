using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SW.schedulity.Courses;
using SW.schedulity.Sections;
using SW.schedulity.UserCourses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.schedulity.Web.Pages;

[Authorize]
public class IndexModel : schedulityPageModel
{
    public IndexModel(ISectionAppService sectionAppService, ICourseAppService courseAppService, IUserCourseRepository userCourseRepository)
    {
        SectionAppService = sectionAppService;
        CourseAppService = courseAppService;
        UserCourseRepository = userCourseRepository;
    }
    public int MyProperty { get; set; }
    public ISectionAppService SectionAppService { get; }
    public ICourseAppService CourseAppService { get; }
    public IUserCourseRepository UserCourseRepository { get; }
    public List<SectionDto> Sections { get; private set; }
    public List<CourseDto> Courses { get; private set; }
    public List<UserCourse> UserCourses { get; private set; }

    public async Task<IActionResult> OnGet()
    {
        if (CurrentUser.IsInRole("admin"))
        {
            return Redirect("/Admin/Index");
        }

        Sections = (await SectionAppService.GetListAsync(new() { })).Items.ToList();
        Courses = (await CourseAppService.GetListAsync(new() { })).Items.ToList();
        UserCourses = (await UserCourseRepository.GetListAsync(x=>x.UserId == CurrentUser.Id)).ToList();

        return Page();
    }
}