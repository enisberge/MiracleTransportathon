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
        public string Type { get; set; } //evden eve, ofis taşıma, büyük hacimli eşya taşıma

        // Nereden Bilgisi (Origin)
        public int OriginCityId { get; set; }
        public int OriginDistrictId { get; set; }
        public int OriginLocalityId { get; set; }
        public string OriginAddress { get; set; }

        // Nereye Bilgisi (Destination)
        public int DestinationCityId { get; set; }
        public int DestinationDistrictId { get; set; }
        public int DestinationLocalityId { get; set; }

        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public Reservation Reservation{ get; set; }
        public List<Offer> Offers { get; set; }

    }
}
