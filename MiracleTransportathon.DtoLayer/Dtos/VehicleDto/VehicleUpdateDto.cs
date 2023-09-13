using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.VehicleDto
{
    public class VehicleUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public int Brand { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public string Plate { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public string DriverPhoneNumber { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CompanyId { get; set; }
    }
}
