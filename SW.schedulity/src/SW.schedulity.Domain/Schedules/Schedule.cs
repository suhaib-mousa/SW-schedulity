using SW.schedulity.Courses;
using SW.schedulity.UserCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SW.schedulity.Schedules
{
    public class Schedule : Entity<Guid>
    {
        public List<UserCourse> UserCourses { get; set; }
        public Guid UserCourseId { get; set; }
        public string Title { get; set; }
    }
}
