using SW.schedulity.Schedules;
using SW.schedulity.Sections;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SW.schedulity.Courses
{
    public class CourseDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int NumberOfHours { get; set; }
        public int order { get; set; }
        public SectionDto Section { get; set; }
        public Guid SectionId { get; set; }
        public CourseType CourseType { get; set; }
    }
}