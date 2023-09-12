using AutoMapper;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User,UserAddDto>();

            CreateMap<UserUpdateDto, User>().ReverseMap();//reverse yapınca yukarıdakiyle aynı oluyor
            CreateMap<UserDeleteDto, User>().ReverseMap();//reverse yapınca yukarıdakiyle aynı oluyor
            CreateMap<UserListDto, User>().ReverseMap();
            CreateMap<RequestAddDto, Request>().ReverseMap();


        }
    }
}
