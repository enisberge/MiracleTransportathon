using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.OfferDto
{
    public class OfferAddDto
    {
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int VehicleId { get; set; }
        public int RequestId { get; set; }
        public int CompanyId { get; set; }
    }
}
