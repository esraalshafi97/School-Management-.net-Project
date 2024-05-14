using schoolManagmentAPI.Data.Entities;
using schoolManagmentAPI.Models;

namespace schoolManagmentAPI.Data.Profile
{
    public class StudentProfile : AutoMapper.Profile
    {
        public StudentProfile() { 
        
          CreateMap<Student, StudentDto>();
          CreateMap<StudentOfCreation, Student>();
        }
      

    }
}
