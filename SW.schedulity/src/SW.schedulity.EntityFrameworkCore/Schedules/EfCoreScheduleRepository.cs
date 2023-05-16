using SW.schedulity.EntityFrameworkCore;
using SW.schedulity.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SW.schedulity.Schedules
{
    public class EfCoreScheduleRepository : EfCoreRepository<schedulityDbContext, Schedule, Guid>, IScheduleRepository
    {
        public EfCoreScheduleRepository(IDbContextProvider<schedulityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
