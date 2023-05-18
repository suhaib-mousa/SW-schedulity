using AutoMapper;
using SW.schedulity.Courses;
using SW.schedulity.Sections;

namespace SW.schedulity.Web;

public class schedulityWebAutoMapperProfile : Profile
{
    public schedulityWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<SectionDto, Section>();
        CreateMap<Section, SectionDto>();
        CreateMap<Course, CourseDto>();
        CreateMap<CourseDto, Course>();
    }
}
