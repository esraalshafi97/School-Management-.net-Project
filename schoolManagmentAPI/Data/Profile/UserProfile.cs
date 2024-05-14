using schoolManagmentAPI.Data.Entities;
using schoolManagmentAPI.Models;

namespace schoolManagmentAPI.Data.Profile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,User >();
        }
    }
}
