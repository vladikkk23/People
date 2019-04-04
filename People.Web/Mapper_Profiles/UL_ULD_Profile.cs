using System;
using AutoMapper;
using People.Domain.Entities.User.UserData;
using People.Domain.Entities.User.UserDataTables;
using People.Web.Models.User;

namespace People.Web.Mapper_Profiles
{
    public class UL_ULD_Profile : Profile
    {
        public UL_ULD_Profile()
        {
            CreateMap<UDataTable, UMinimalData>();
        }
    }
}
