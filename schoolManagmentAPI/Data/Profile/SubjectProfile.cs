
using cityInfo.api.Models;
using schoolManagmentAPI.Data.Entities;

namespace school.Profile
{
    public class SubjectProfile : AutoMapper.Profile
    {
        public SubjectProfile() {
        
            CreateMap<Subject, Models.SubjectWithoutTeachersDto>();
            CreateMap<Subject, SubjectDto>();


        }
    }
}
