using SW.schedulity.Courses;
using SW.schedulity.Schedules;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace SW.schedulity.UserCourses
{
    public class UserCourseDto : EntityDto
    {
        List<ScheduleDto> Schedules;
        public Guid UserId { get; set; }
        public IdentityUserDto User { get; set; }
        public Guid CourseId { get; set; }
        public CourseDto Course { get; set; }
        public bool IsPassed { get; set; }
    }
}
