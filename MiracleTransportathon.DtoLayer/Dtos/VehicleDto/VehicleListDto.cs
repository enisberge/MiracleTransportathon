using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.VehicleDto
{
    public class VehicleListDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CompanyId { get; set; }
    }
}
