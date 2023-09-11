using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.UserDto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı girin.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı girin.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen e-posta adresinizi girin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adı girin.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen parolanızı girin.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Parolanız en az 8 karakter uzunluğunda olmalıdır.")]
        [MaxLength(14, ErrorMessage = "Parolanız en fazla 14 karakter uzunluğunda olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı girin.")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public int Role { get; set; }
    }
}
