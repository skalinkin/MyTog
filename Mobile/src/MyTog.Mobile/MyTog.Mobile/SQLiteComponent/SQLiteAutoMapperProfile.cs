using AutoMapper;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class SQLiteAutoMapperProfile : Profile
    {
        public SQLiteAutoMapperProfile()
        {
            CreateMap<AccessTokenLifetime, AccessTokenLifetimeRecord>().ReverseMap();
            CreateMap<ApplicationMode, ApplicationModeRecord>().ReverseMap();
        }
    }
}