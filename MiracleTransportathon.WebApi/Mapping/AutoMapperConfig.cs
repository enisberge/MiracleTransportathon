using AutoMapper;
using MiracleTransportathon.DtoLayer.Dtos.CityDto;
using MiracleTransportathon.DtoLayer.Dtos.OfferDto;
using MiracleTransportathon.DtoLayer.Dtos.CompanyDto;
using MiracleTransportathon.DtoLayer.Dtos.MessageDto;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.DtoLayer.Dtos.VehicleDto;
using MiracleTransportathon.EntityLayer.Concrete;
using MiracleTransportathon.DtoLayer.Dtos.LoginDto;

namespace MiracleTransportathon.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User,UserAddDto>();

            CreateMap<User, RegisterUserDto>().ReverseMap();

            
            CreateMap<UserUpdateDto, User>().ReverseMap();//reverse yapınca yukarıdakiyle aynı oluyor
            CreateMap<UserDeleteDto, User>().ReverseMap();//reverse yapınca yukarıdakiyle aynı oluyor
            CreateMap<UserListDto, User>().ReverseMap();
            CreateMap<RequestAddDto, Request>().ReverseMap();
            CreateMap<RegisterUserDto, User>().ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();



            CreateMap<VehicleAddDto, Vehicle>().ReverseMap();
            CreateMap<VehicleDeleteDto, Vehicle>().ReverseMap();
            CreateMap<VehicleListDto, Vehicle>().ReverseMap();
            CreateMap<CityListDto, City>().ReverseMap();
            CreateMap<OfferAddDto,Offer>().ReverseMap();

            CreateMap<CompanyAddDto, Company>().ReverseMap();
            CreateMap<CompanyDeleteDto, Company>().ReverseMap();
            CreateMap<CompanyListDto, Company>().ReverseMap();

            CreateMap<CreateMessageDto, Message>().ReverseMap();
            CreateMap<InboxMessageDto, Message>().ReverseMap();
        }
    }
}
