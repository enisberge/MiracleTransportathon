namespace MiracleTransportathon.WebUI.Models.Offer
{
    public class AddOfferViewModel
    {
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int VehicleId { get; set; }
        public int RequestId { get; set; }
        public int CompanyId { get; set; } = 1;
    }
}
