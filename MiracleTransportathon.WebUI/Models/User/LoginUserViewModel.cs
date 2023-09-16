using System.ComponentModel.DataAnnotations;

namespace MiracleTransportathon.WebUI.Models.User
{
    public class LoginUserViewModel
    {

        [Required(ErrorMessage = "Kullanıcı adı bilgisi boş geçilemez !")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola bilgisi boş geçilemez !")]
        public string Password { get; set; }
    }
}
