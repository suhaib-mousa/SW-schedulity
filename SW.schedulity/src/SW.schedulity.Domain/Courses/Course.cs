using SW.schedulity.Schedules;
using SW.schedulity.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SW.schedulity.Courses
{
    public class Course : AggregateRoot<Guid>
    {
        public string Title { get; set; }
        public int NumberOfHours { get; set; }
        public int order { get; set; }
        public Section Section { get; set; }
        public Guid SectionId { get; set; }
        public CourseType CourseType { get; set; }
        public Guid ParentId { get; set; }
    }
}
