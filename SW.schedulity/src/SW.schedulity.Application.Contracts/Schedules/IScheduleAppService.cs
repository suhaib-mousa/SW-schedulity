using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SW.schedulity.Schedules
{
    public interface IScheduleAppService : ICrudAppService<ScheduleDto, Guid>
    {
        public Task<ScheduleCourseDto> GenerateAsync(int numberOfCourses, bool includeGeneralRequirement = false);
    }
}
