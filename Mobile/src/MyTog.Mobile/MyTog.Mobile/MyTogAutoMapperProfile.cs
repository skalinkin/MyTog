using AutoMapper;

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