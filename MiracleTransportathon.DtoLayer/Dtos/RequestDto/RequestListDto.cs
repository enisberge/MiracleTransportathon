using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.RequestDto
{
    public class RequestListDto
    {
        public int RequestId { get; set; }
        public int RequestType { get; set; }
        public string OriginCityName { get; set; }
        public string DestinationCityName { get; set; }
        public string OriginDistrictName { get; set; }
        public string DestinationDistrictName { get; set; }
        public string OriginLocalityName { get; set; }
        public string DestinationLocalityName { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationAddress { get; set; }
        public int OriginLift { get; set; }
        public int DestinationLift { get; set; }
        public DateTime MovingDate { get; set; }
        public string ApartmentType { get; set; }
        public string ExtraService { get; set; }
        public string RequestDescription { get; set; }
        public string BigItemDetails { get; set; }
        public int RequestStatus { get; set; }
        public DateTime RequestCreatedDate { get; set; }
        public int UserId { get; set; }
        public int OfferCount { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phonenumber { get; set; }


    }
}
