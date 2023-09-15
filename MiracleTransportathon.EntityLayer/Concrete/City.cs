using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class City
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlateNumber { get; set; }

        public List<District> Districts  { get; set; }//İlçe
        public List<Request>OriginRequests { get; set; }
        public List<Request> DestinationRequests { get; set; }
    }
}
