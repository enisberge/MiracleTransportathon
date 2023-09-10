using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.UserDto
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int Role { get; set; } //kullanıcı veya taşıyıcı
        public DateTime CreatedDate { get; set; }

    }
}
