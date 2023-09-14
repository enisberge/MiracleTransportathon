namespace MiracleTransportathon.WebUI.Models.Company
{
    public class UpdateCompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; } //şirket tipi
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
