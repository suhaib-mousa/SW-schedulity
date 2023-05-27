using SW.schedulity.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.schedulity.Schedules;

public class ScheduleCourseDto 
{
    public List<CourseDto> SpecialiaztionCourses { get; set; }
    public int NumberOfPracitcalCourses { get; set; } = 0;
    public int NumberOfTheoreticalCourses { get; set; } = 0;
    public List<CourseDto> UniversityCourses { get; set; }
    public List<CourseDto> GeneralCourses { get; set; }

}
