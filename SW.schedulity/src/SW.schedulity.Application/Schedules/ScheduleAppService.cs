using SW.schedulity.Courses;
using SW.schedulity.Sections;
using SW.schedulity.UserCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace SW.schedulity.Schedules
{
    public class ScheduleAppService : CrudAppService<Schedule, ScheduleDto, Guid>, IScheduleAppService
    {
        public IUserCourseRepository UserCourseRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public ISectionAppService SectionAppService { get; }

        public ScheduleAppService(IUserCourseRepository userCourseRepository,
            ICourseRepository courseRepository,
            ISectionAppService sectionAppService,
            IRepository<Schedule, Guid> repository) : base(repository)
        {
            UserCourseRepository = userCourseRepository;
            CourseRepository = courseRepository;
            SectionAppService = sectionAppService;
        }

        public async Task<ScheduleCourseDto> GenerateAsync(int numberOfCourses, bool includeGeneralRequirement = false)
        {
            numberOfCourses /= 3;

            var scheduleCourseDto = new ScheduleCourseDto(); 

            var userCourses = await UserCourseRepository.GetListAsync(u => u.UserId == CurrentUser.Id);
            var courses = (await CourseRepository.GetListAsync(true)).Where(x => !userCourses.Any(u => u.CourseId == x.Id)).ToList();

            if (includeGeneralRequirement)
            {
                var generalCourse =  courses.Where(i => i.Section.SectionType == SectionType.GeneralRequirements &&userCourses.Any(u => u.CourseId == i.ParentId)).ToList();
                if (generalCourse != null)
                {
                    scheduleCourseDto.GeneralCourses = ObjectMapper.Map<List<Course>, List<CourseDto>>(generalCourse); 
                }
            }

            var universityRequirements = courses.Where(c =>
            c.Section.SectionType == SectionType.ElectiveUniversityRequirements ||
            c.Section.SectionType == SectionType.ObligatoryUniversityRequirements
            ).ToList();

            if (universityRequirements.Any() && numberOfCourses > 9)
            {
                scheduleCourseDto.UniversityCourses = ObjectMapper.Map<List<Course>, List<CourseDto>>(universityRequirements);
                numberOfCourses -= 3;
            }

            var specialiaztionCourses = courses.Where(i => userCourses.Any(u => u.CourseId == i.ParentId) &&
            i.Section.SectionType == SectionType.ObligatorySpecialiaztionRequirements ||
            i.Section.SectionType == SectionType.ElectiveSpecialiaztionRequirements ||
            i.Section.SectionType == SectionType.ObligatoryFacultyRequirements
            ).OrderBy(x=>x.order)
            .ToList();
            if (specialiaztionCourses.Any(x=>x.CourseType == CourseType.practical))
            {
                scheduleCourseDto.NumberOfPracitcalCourses = numberOfCourses % 2 == 0 ? numberOfCourses / 2 : numberOfCourses / 2 + 1;
            }
            if (specialiaztionCourses.Any(x=>x.CourseType == CourseType.theoretical))
            {
                scheduleCourseDto.NumberOfTheoreticalCourses = numberOfCourses - scheduleCourseDto.NumberOfPracitcalCourses;
            }
            scheduleCourseDto.SpecialiaztionCourses = ObjectMapper.Map<List<Course>, List<CourseDto>>(specialiaztionCourses);

            return scheduleCourseDto;
        } 
    }
}
