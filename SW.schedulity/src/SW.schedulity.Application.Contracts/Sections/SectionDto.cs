using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SW.schedulity.Sections
{
    public class SectionDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int NumberOfHours { get; set; }
        public int order { get; set; }
        public SectionType SectionType { get; set; }
    }
}
