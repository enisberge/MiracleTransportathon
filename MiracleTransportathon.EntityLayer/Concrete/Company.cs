using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; } //şirket tipi
        public string? Address { get; set; }
        public string? WebSite { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
