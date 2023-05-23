using SW.schedulity.Schedules;
using SW.schedulity.Sections;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using static System.Collections.Specialized.BitVector32;

namespace SW.schedulity.Courses
{
    public class CourseDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int NumberOfHours { get; set; }
        public int order { get; set; }
        public bool IsPassed { get; set; }
        public SectionDto Section { get; set; }
        public Guid SectionId { get; set; }
        public List<ScheduleDto> Shcedules { get; set; }
        public CourseType CourseType { get; set; }
    }
}