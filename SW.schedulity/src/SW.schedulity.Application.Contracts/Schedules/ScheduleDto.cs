using SW.schedulity.Courses;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SW.schedulity.Schedules
{
    public class ScheduleDto : EntityDto<Guid>
    {
        public List<CourseDto> Courses { get; set; }
        public string ShceduleTitle { get; set; }
    }
}