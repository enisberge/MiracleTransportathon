using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Type { get; set; } //aracın tipi (kamyon,kamyonet,tır)
        public int Brand { get; set; } //mercedes, man, Iveco,BMC
        public int Model { get; set; }

        public string Plate { get; set; }

        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public DateTime Year { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public List<Offer> Offers { get; set; }

    }
}
