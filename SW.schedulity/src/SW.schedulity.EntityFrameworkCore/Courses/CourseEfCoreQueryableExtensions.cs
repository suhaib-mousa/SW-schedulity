using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.schedulity.Courses
{
    public static class CourseEfCoreQueryableExtensions
    {
        public static IQueryable<Course> IncludeDetails(
            this IQueryable<Course> queryable,
            bool include = true)
        {
            if (include)
            {
                return queryable
                    .Include(e => e.Section);
            }

            return queryable;
        }
    }
}
