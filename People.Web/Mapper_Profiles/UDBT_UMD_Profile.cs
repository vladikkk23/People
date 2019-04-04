using System;
using AutoMapper;
using People.Domain.Entities.User.UserData;
using People.Web.Models.User;

namespace People.Web.Mapper_Profiles
{
    public class UDBT_UMD_Profile : Profile
    {
        public UDBT_UMD_Profile()
        {
            CreateMap<UserLogin, ULoginData>();
        }
    }
}
