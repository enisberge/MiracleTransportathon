using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.CompanyDto
{
    public class CompanyUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş geçilemez.")]
        public string Name { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
