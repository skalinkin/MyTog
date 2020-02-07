using AutoMapper;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile
{
    internal class MyTogAutoMapperProfile : Profile
    {
        public MyTogAutoMapperProfile()
        {
            CreateMap<User, CreateUserCommand>();
        }
    }
}