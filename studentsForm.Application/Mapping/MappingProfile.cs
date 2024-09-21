using AutoMapper;
using studentsForm.Application.ViewModel;
using studentsForm.Core.Models;

namespace studentsForm.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddStudentVM, Student>();
            CreateMap<Subject, SubjectVM>().ReverseMap();
        }
    }
}
