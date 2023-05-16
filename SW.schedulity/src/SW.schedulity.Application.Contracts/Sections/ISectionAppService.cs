using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace SW.schedulity.Sections
{
    public interface ISectionAppService : ICrudAppService<SectionDto, Guid>
    {
    }
}
