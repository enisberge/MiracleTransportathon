namespace MiracleTransportathon.WebUI.Models.Company
{
    public class AddCompanyViewModel
    {        
        public string Name { get; set; }
        public int Type { get; set; } //şirket tipi
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
