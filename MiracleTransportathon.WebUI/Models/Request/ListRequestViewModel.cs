namespace MiracleTransportathon.WebUI.Models.Request
{
    public class ListRequestViewModel
    {
        public int Id { get; set; }
        public int Type { get; set; } //evden eve, ofis taşıma, büyük hacimli eşya taşıma

        // Nereden Bilgisi (Origin)
        public int OriginCityId { get; set; }
        public int OriginDistrictId { get; set; }
        public int OriginLocalityId { get; set; }
        public string OriginAddress { get; set; }
        public int OriginLift { get; set; }
        public int DestinationLift { get; set; }
        //ne zaman taşınacak
        public DateTime MovingDate { get; set; }
        // Nereye Bilgisi (Destination)
        public int DestinationCityId { get; set; }
        public int DestinationDistrictId { get; set; }
        public int DestinationLocalityId { get; set; }
        public string DestinationAddress { get; set; }
        public string BigItemDetails { get; set; }
        public string ApartmentType { get; set; }

        public string ExtraService { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
    }
}
