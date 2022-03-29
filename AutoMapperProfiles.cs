using aljuvifoods_webapi.DTOs.User;
using aljuvifoods_webapi.Models;
using AutoMapper;

namespace aljuvifoods_webapi
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserCDTO>();
            CreateMap<UserCDTO, User>();
        }

        
    }
}
