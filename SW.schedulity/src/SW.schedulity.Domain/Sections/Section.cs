using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SW.schedulity.Sections
{
    public class Section : AggregateRoot<Guid>
    {
        public string Title { get; set; }
        public int NumberOfHours { get; set; }
        public int order { get; set; }
        public SectionType SectionType { get; set; }
    }
}
