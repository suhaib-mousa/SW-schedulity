using SW.schedulity.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SW.schedulity.UserCourses;

public class UserCourseAppService : ApplicationService
{
    public UserCourseAppService(IUserCourseRepository userCourseRepository, ICourseRepository courseRepository)
    {
        UserCourseRepository = userCourseRepository;
        CourseRepository = courseRepository;
    }

    public IUserCourseRepository UserCourseRepository { get; }
    public ICourseRepository CourseRepository { get; }

    public async Task<UserCourseDto> CreateIfNotExistAsync(Guid courseId)
    {
        if (!(await UserCourseRepository.GetListAsync(x => x.CourseId == courseId && x.UserId == CurrentUser.Id)).Any())
        {
            var userCourse =  await UserCourseRepository.InsertAsync(new UserCourse()
            {
                CourseId = courseId,
                UserId = CurrentUser.Id.Value,
                IsPassed = true
            });
            return ObjectMapper.Map<UserCourse, UserCourseDto>(userCourse);
        }
        return new UserCourseDto();
    }
    public async Task DeleteAsync(Guid courseId)
    {
        await UserCourseRepository.DeleteAsync(x=>x.CourseId == courseId && x.UserId == CurrentUser.Id);
    }
    public async Task<List<UserCourseDto>> GetUserListAsync()
    {
        var userCourses = await UserCourseRepository.GetListAsync(x=>x.UserId == CurrentUser.Id);
        return ObjectMapper.Map<List<UserCourse>, List<UserCourseDto>>(userCourses);
    }
    public async Task<bool> IsChecked(Guid courseId)
    {
        return (await UserCourseRepository.GetAsync(c=>c.CourseId == courseId)) != null;
    }
    public async Task<int> ProgressAsPercentage()
    {
        var userCourses = await GetUserListAsync();
        var courses = await CourseRepository.GetListAsync();
        return (int)((float)userCourses.Count / courses.Count * 100);
    }
}
