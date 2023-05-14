using SW.schedulity.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SW.schedulity.Schedules
{
    public class Shcedule : Entity<Guid>
    {
        public List<Course> Courses { get; set; }
        public string ShceduleTitle { get; set; }
    }
}
