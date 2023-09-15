using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Locality
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public int LocalityId { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public List<Request> OriginRequests { get; set; }
        public List<Request> DestinationRequests { get; set; }

    }
}
