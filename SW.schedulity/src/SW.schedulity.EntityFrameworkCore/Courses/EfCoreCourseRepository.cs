using SW.schedulity.EntityFrameworkCore;
using SW.schedulity.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SW.schedulity.Courses
{
    public class EfCoreCourseRepository : EfCoreRepository<schedulityDbContext, Course, Guid>, ICourseRepository
    {
        public EfCoreCourseRepository(IDbContextProvider<schedulityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
