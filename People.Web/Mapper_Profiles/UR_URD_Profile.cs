using System;
using AutoMapper;
using People.Domain.Entities.User.UserData;
using People.Web.Models.User;

namespace People.Web.Mapper_Profiles
{
    public class UR_URD_Profile : Profile
    {
        public UR_URD_Profile()
        {
            CreateMap<UserRegister, URegisterData>();
        }
    }
}
