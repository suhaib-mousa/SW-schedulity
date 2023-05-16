using SW.schedulity.EntityFrameworkCore;
using SW.schedulity.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SW.schedulity.Sections
{
    public class EfCoreSectionRepository : EfCoreRepository<schedulityDbContext, Section, Guid>, ISectionRepository
    {
        public EfCoreSectionRepository(IDbContextProvider<schedulityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
