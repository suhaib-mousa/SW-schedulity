using SW.schedulity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SW.schedulity.UserCourses
{
    public class EfCoreUserCourseRepository :
        EfCoreRepository<schedulityDbContext, UserCourse>,
    IUserCourseRepository
    {
        public EfCoreUserCourseRepository(IDbContextProvider<schedulityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
