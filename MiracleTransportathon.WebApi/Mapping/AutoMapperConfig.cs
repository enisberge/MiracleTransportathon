using AutoMapper;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.DtoLayer.Dtos.VehicleDto;
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


            CreateMap<VehicleAddDto, Vehicle>().ReverseMap();
            CreateMap<VehicleDeleteDto, Vehicle>().ReverseMap();
            CreateMap<VehicleListDto, Vehicle>().ReverseMap();


        }
    }
}
