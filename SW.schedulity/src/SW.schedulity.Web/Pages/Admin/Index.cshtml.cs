using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.schedulity.Courses;
using SW.schedulity.Schedules;
using SW.schedulity.Sections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace SW.schedulity.Web.Pages.Admin;

[Authorize(Roles = "admin")]
public class IndexModel : PageModel
{
    private readonly IScheduleAppService ScheduleAppService;
    public IIdentityUserAppService IdentityUserAppService { get; }
    public ICourseAppService CourseAppService { get; }
    public ISectionAppService SectionAppService { get; }
    public IndexModel(IIdentityUserAppService identityUserAppService,
                        IScheduleAppService schedulesAppService,
                        ICourseAppService courseAppService,
                        ISectionAppService sectionAppService)
    {
        IdentityUserAppService = identityUserAppService;
        ScheduleAppService = schedulesAppService;
        CourseAppService = courseAppService;
        SectionAppService = sectionAppService;
    }
    public long UsersCount { get; private set; }
    public long SchedulesCount { get; private set; }
    public List<SectionDto> Sections { get; set; }
    public List<CourseDto> Courses { get; set; }
    public async Task OnGet()
    {
        UsersCount = (await IdentityUserAppService.GetListAsync(new() { })).TotalCount;

        SchedulesCount = (await ScheduleAppService.GetListAsync(new() { })).TotalCount;

        Sections = (await SectionAppService.GetListAsync(new() {  })).Items.ToList();

        Courses = (await CourseAppService.GetListAsync(new() {  })).Items.ToList();
    }
}


