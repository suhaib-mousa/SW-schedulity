using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SW.schedulity.Courses
{
    public class CourseAppService : CrudAppService<Course, CourseDto, Guid>, ICourseAppService
    {
        public CourseAppService(IRepository<Course, Guid> repository) : base(repository)
        {
        }
    }
}
