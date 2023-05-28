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

            var generalCourse = courses.Where(i => i.Section.SectionType == SectionType.GeneralRequirements && !userCourses.Any(x=>x.CourseId == i.Id)).ToList();
            var co = ObjectMapper.Map<List<Course>, List<CourseDto>>(generalCourse);
            if (includeGeneralRequirement)
            {
                if (generalCourse.Any())
                {
                    scheduleCourseDto.Courses.Add(co[0]);
                    co.RemoveAt(0);
                    if (co.Count > 0)
                    {
                        scheduleCourseDto.RestCourses.Add(co[0]);
                    }
                }
            }

            var universityRequirements = courses.Where(c =>
                c.Section.SectionType == SectionType.ElectiveUniversityRequirements ||
                c.Section.SectionType == SectionType.ObligatoryUniversityRequirements
            ).ToList();

            var co2 = ObjectMapper.Map<List<Course>, List<CourseDto>>(universityRequirements);
            if (universityRequirements.Any() && numberOfCourses > 9)
            {
                scheduleCourseDto.Courses.Add(co2[0]);
                co2.RemoveAt(0);
                numberOfCourses--;
                if (co2.Count > 0)
                {
                    scheduleCourseDto.RestCourses.Add(co2[0]);
                    co2.RemoveAt(0);
                }
            }

            var specialiaztionCourses = courses.Where(i => userCourses.Any(u => u.CourseId == i.ParentId) &&
                (i.Section.SectionType == SectionType.ObligatorySpecialiaztionRequirements ||
                 i.Section.SectionType == SectionType.ElectiveSpecialiaztionRequirements ||
                 i.Section.SectionType == SectionType.ObligatoryFacultyRequirements)
            ).OrderBy(x => x.order)
            .ToList();

            var co3 = ObjectMapper.Map<List<Course>, List<CourseDto>>(specialiaztionCourses);
            if (specialiaztionCourses.Count > 0)
            {
                for (int i = 0; i < co3.Count; i++)
                {
                    var course = co3[i];
                    scheduleCourseDto.Courses.Add(course);
                    co3.RemoveAt(i);
                    numberOfCourses--;
                    if (numberOfCourses == 0)
                    {
                        break;
                    }
                    // Adjust the loop index if an item is removed
                    i--;
                }
                if (numberOfCourses == 0)
                {
                    foreach (var c in co3)
                    {
                        scheduleCourseDto.RestCourses.Add(c);
                    }

                }
            }
            if (co3.Count > 0 && numberOfCourses > 0)
            {
                for (int i = 0; i < co3.Count; i++)
                {
                    var course = co3[i];
                    scheduleCourseDto.Courses.Add(course);
                    co3.RemoveAt(i);
                    numberOfCourses--;
                    if (numberOfCourses == 0)
                    {
                        break;
                    }
                    // Adjust the loop index if an item is removed
                    i--;
                }
            }
            if (co2.Count > 0 && numberOfCourses > 0)
            {
                for (int i = 0; i < co2.Count; i++)
                {
                    var course = co2[i];
                    scheduleCourseDto.Courses.Add(course);
                    co2.RemoveAt(i);
                    numberOfCourses--;
                    if (numberOfCourses == 0)
                    {
                        break;
                    }
                    // Adjust the loop index if an item is removed
                    i--;
                }
            }

            if (co.Count > 0 && includeGeneralRequirement && numberOfCourses > 0)
            {
                for (int i = 0; i < co.Count; i++)
                {
                    var course = co[i];
                    scheduleCourseDto.Courses.Add(course);
                    co.RemoveAt(i);
                    numberOfCourses--;
                    if (numberOfCourses == 0)
                    {
                        break;
                    }
                    // Adjust the loop index if an item is removed
                    i--;
                }
            }
            
            return scheduleCourseDto;
        }
    }
}
