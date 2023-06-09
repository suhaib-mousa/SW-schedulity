﻿using AutoMapper;
using SW.schedulity.Courses;
using SW.schedulity.UserCourses;

namespace SW.schedulity;

public class schedulityApplicationAutoMapperProfile : Profile
{
    public schedulityApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<UserCourse, UserCourseDto>();
        CreateMap<Course, CourseDto>();
    }
}
