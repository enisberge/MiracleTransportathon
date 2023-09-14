using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class District

    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int DistrictId { get; set; }
        //İlişkiler
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Locality>Localities { get; set; }

        public List<Request> OriginRequests { get; set; }

        public List<Request> DestinationRequests{ get; set; }

    }
}
