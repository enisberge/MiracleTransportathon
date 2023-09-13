namespace MiracleTransportathon.WebUI.Models.Vehicle
{
    public class AddVehicleViewModel
    {       
        public int Type { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CompanyId { get; set; } = 1;
    }
}
