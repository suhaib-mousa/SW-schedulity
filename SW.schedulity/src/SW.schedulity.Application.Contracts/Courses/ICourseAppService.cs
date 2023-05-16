using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using static System.Collections.Specialized.BitVector32;

namespace SW.schedulity.Courses
{
    public interface ICourseAppService : ICrudAppService<CourseDto, Guid>
    {
    }
}
