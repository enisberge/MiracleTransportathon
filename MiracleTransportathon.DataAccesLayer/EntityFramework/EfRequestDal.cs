using Microsoft.EntityFrameworkCore;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace EnisBlog.DataAccessLayer.EntityFramework
{
    public class EfRequestDal : GenericRepository<Request>, IRequestDal
    {
        public EfRequestDal(Context context) : base(context)
        {
        }

        public List<RequestListDto> GetAllRequest()
        {
            var context = new Context();
            var results = context.Requests
    .GroupJoin(
        context.Offers,
        r => r.Id,
        o => o.RequestId,
        (r, offerGroup) => new
        {
            RequestId = r.Id,
            RequestType = r.Type,
            OriginCityName = r.OriginCity.Name,
            DestinationCityName = r.DestinationCity.Name,
            OriginDistrictName = r.OriginDistrict.Name,
            DestinationDistrictName = r.DestinationDistrict.Name,
            OriginLocalityName = r.OriginLocality.Name,
            DestinationLocalityName = r.DestinationLocality.Name,
            OriginAddress = r.OriginAddress,
            DestinationAddress = r.DestinationAddress,
            UserId = r.UserId,
            Name = r.User.Name,
            Surname = r.User.Surname,
            UserPhoneNumber = r.User.PhoneNumber,
            MovingDate = r.MovingDate,
            RequestedCreatedDate = r.CreatedDate,
            OfferCount = offerGroup.Count()
        })
    .ToList();



            var filledResults = results.Select(result => new RequestListDto
            {
                RequestId = result.RequestId,
                RequestType = result.RequestType,
                OriginCityName = result.OriginCityName,
                DestinationCityName = result.DestinationCityName,
                OriginDistrictName = result.OriginDistrictName,
                DestinationDistrictName = result.DestinationDistrictName,
                OriginLocalityName = result.OriginLocalityName,
                DestinationLocalityName = result.DestinationLocalityName,
                OriginAddress = result.OriginAddress,
                DestinationAddress = result.DestinationAddress,
                UserId = result.UserId,
                Name = result.Name,
                Surname = result.Surname,
                Phonenumber = result.UserPhoneNumber,
                MovingDate = result.MovingDate,
                RequestCreatedDate = result.RequestedCreatedDate,
                OfferCount = result.OfferCount
            }).ToList();

            return filledResults;


        }

        public RequestListDto GetRequestById(int requestId)
        {
            var context = new Context();
            var result = context.Requests
                .Where(r => r.Id == requestId) // Talebi ID'ye göre filtreleyin
                .GroupJoin(
                    context.Offers,
                    r => r.Id,
                    o => o.RequestId,
                    (r, offerGroup) => new
                    {
                        RequestId = r.Id,
                        RequestType = r.Type,
                        OrigiLift = r.OriginLift,
                        DestinationLift= r.DestinationLift,
                        ApartmentType=r.ApartmentType,
                        ExtraService=r.ExtraService,
                        RequestDescription=r.Description,
                        OriginCityName = r.OriginCity.Name,
                        DestinationCityName = r.DestinationCity.Name,
                        OriginDistrictName = r.OriginDistrict.Name,
                        DestinationDistrictName = r.DestinationDistrict.Name,
                        OriginLocalityName = r.OriginLocality.Name,
                        DestinationLocalityName = r.DestinationLocality.Name,
                        OriginAddress = r.OriginAddress,
                        DestinationAddress = r.DestinationAddress,
                        UserId = r.UserId,
                        Name = r.User.Name,
                        Surname = r.User.Surname,
                        UserPhoneNumber = r.User.PhoneNumber,
                        MovingDate = r.MovingDate,
                        RequestedCreatedDate = r.CreatedDate,
                        OfferCount = offerGroup.Count()
                    })
                .FirstOrDefault(); // İlk eşleşen talebi alın veya null döndürün

            if (result != null)
            {
                var filledResult = new RequestListDto
                {
                    RequestId = result.RequestId,
                    RequestType = result.RequestType,
                    OriginCityName = result.OriginCityName,
                    DestinationCityName = result.DestinationCityName,
                    OriginDistrictName = result.OriginDistrictName,
                    DestinationDistrictName = result.DestinationDistrictName,
                    OriginLocalityName = result.OriginLocalityName,
                    DestinationLocalityName = result.DestinationLocalityName,
                    OriginAddress = result.OriginAddress,
                    DestinationAddress = result.DestinationAddress,
                    UserId = result.UserId,
                    Name = result.Name,
                    Surname = result.Surname,
                    Phonenumber = result.UserPhoneNumber,
                    MovingDate = result.MovingDate,
                    RequestCreatedDate = result.RequestedCreatedDate,
                    DestinationLift = result.DestinationLift,
                    ApartmentType = result.ApartmentType,
                    ExtraService = result.ExtraService,
                    RequestDescription = result.RequestDescription,
                    OfferCount = result.OfferCount
                };
                return filledResult;
            }

            return null; // Eşleşen bir talep bulunamazsa null döndürün
        }

    }
}
