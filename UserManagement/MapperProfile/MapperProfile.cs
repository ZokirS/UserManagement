using AutoMapper;
using UserManagement.Entities;
using UserManagement.Models;

namespace UserManagement.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
