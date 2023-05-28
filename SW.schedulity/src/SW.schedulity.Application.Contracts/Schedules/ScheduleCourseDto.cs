using SW.schedulity.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.schedulity.Schedules;

public class ScheduleCourseDto 
{
    public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    public List<CourseDto> RestCourses { get; set; } = new List<CourseDto>();

}
