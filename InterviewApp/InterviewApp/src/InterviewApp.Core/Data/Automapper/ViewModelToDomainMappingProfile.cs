using AutoMapper;
using InterviewApp.Core.Data.Entities;
using InterviewApp.Core.Handler.Student.Query.GetStudents;
using InterviewApp.Core.Handler.Student.Query.GetStudentsSorted;

namespace InterviewApp.Core.Data.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentModel, Student>();
            CreateMap<StudentSortedModel, Student>();
            CreateMap<Student, StudentModel>();
            CreateMap<Student, StudentSortedModel>();
        }
    }
}