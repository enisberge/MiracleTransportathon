namespace MiracleTransportathon.WebUI.Models.Vehicle
{
    public class UpdateVehicleViewModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public DateTime Year { get; set; }
        public int CompanyId { get; set; }
    }
}
