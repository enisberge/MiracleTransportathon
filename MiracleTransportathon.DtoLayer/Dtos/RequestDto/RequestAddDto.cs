using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.RequestDto
{
    public class RequestAddDto
    {
        public int Id { get; set; }
        public int Type { get; set; } //evden eve, ofis taşıma, büyük hacimli eşya taşıma

        // Nereden Bilgisi (Origin)
        public int OriginCityId { get; set; }
        public int OriginDistrictId { get; set; }
        public int OriginLocalityId { get; set; }
        public string OriginAddress { get; set; }
        //ne zaman taşınacak
        public int OriginLift { get; set; }
        public int DestinationLift { get; set; }

        [Required(ErrorMessage = "Taşıma tarihi bilgisi boş geçilemez.")]
        public DateTime MovingDate { get; set; }
        // Nereye Bilgisi (Destination)
        public int DestinationCityId { get; set; }
        public int DestinationDistrictId { get; set; }
        public int DestinationLocalityId { get; set; }
        public string DestinationAddress { get; set; }
        public string ApartmentType { get; set; }

        public string ExtraService { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
    }
}
