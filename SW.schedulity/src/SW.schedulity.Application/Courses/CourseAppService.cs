using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SW.schedulity.Courses
{
    public class CourseAppService : CrudAppService<Course, CourseDto, Guid>, ICourseAppService
    {
        public CourseAppService(IRepository<Course, Guid> repository) : base(repository)
        {
        }
        public override Task<PagedResultDto<CourseDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            input.MaxResultCount = int.MaxValue;
            return base.GetListAsync(input);
        }
    }
}
