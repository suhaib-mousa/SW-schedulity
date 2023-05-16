using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SW.schedulity.Sections
{
    public class SectionAppService : CrudAppService<Section, SectionDto, Guid>, ISectionAppService
    {
        public SectionAppService(IRepository<Section, Guid> repository) : base(repository)
        {
        }
    }
}
