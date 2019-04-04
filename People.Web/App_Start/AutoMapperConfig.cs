using AutoMapper;
using People.Web.Mapper_Profiles;

namespace People.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UDBT_UMD_Profile>();
                cfg.AddProfile<UL_ULD_Profile>();
                cfg.AddProfile<UR_URD_Profile>();
            }
            );
        }
    }
}