using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Offer
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
