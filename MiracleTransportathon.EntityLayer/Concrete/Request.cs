using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Request
    {
        public int Id { get; set; }
        public int Type { get; set; } //evden eve, ofis taşıma, büyük hacimli eşya taşıma

        // Nereden Bilgisi (Origin)
       
        public string OriginAddress { get; set; }
        public int OriginLift { get; set; }
        public int DestinationLift { get; set; }
        //ne zaman taşınacak
        public DateTime MovingDate { get; set; }
        // Nereye Bilgisi (Destination)
     
        public string DestinationAddress { get; set; }

        public string ApartmentType { get; set; }

        public string ExtraService { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public Reservation Reservation{ get; set; }
        public List<Offer> Offers { get; set; }


        public int OriginCityId { get; set; }
        public City OriginCity { get; set; }
        public int OriginDistrictId { get; set; }
        public District OriginDistrict{ get; set; }
        public int OriginLocalityId { get; set; }
        public Locality OriginLocality { get; set; }


        public int DestinationCityId { get; set; }
        public City DestinationCity { get; set; }
        public int DestinationDistrictId { get; set; }
        public District DestinationDistrict { get; set; }
        public int DestinationLocalityId { get; set; }
        public Locality DestinationLocality { get; set; }

    }
}
