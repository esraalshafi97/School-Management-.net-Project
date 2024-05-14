
using cityInfo.api.Models;
using schoolManagmentAPI.Data.Entities;

namespace school.Profile
{
    public class TeacherProfile : AutoMapper.Profile
    {
        public TeacherProfile() {
        
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherCreation, Teacher>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.NationalNumber, opt => opt.MapFrom(src => src.NationalNumber))
             .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
             .ForMember(dest => dest.ImageUrl, opt => {
                  opt.MapFrom(src => src.TeacherImage != null ? Convert.ToBase64String(ReadStreamToByteArray(src.TeacherImage.OpenReadStream())) : null);

             });

        }

        private static byte[] ReadStreamToByteArray(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
