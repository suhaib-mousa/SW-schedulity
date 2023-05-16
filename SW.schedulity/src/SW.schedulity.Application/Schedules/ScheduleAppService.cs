using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SW.schedulity.Schedules
{
    public class ScheduleAppService : CrudAppService<Schedule, ScheduleDto, Guid>, IScheduleAppService
    {
        public ScheduleAppService(IRepository<Schedule, Guid> repository) : base(repository)
        {
        }
    }
}
