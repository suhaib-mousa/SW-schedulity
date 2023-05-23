using SW.schedulity.Courses;
using SW.schedulity.Schedules;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace SW.schedulity.UserCourses
{
    public class UserCourse : BasicAggregateRoot
    {
        List<Schedule> Schedules;
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public bool IsPassed { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { UserId, CourseId };
        }
    }
}
