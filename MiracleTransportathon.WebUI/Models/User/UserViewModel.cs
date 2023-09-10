namespace MiracleTransportathon.WebUI.Models.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int Role { get; set; } //kullanıcı, taşıyıcı,admin
        public DateTime CreatedDate { get; set; }
    }
}
