using System.ComponentModel.DataAnnotations;

namespace MiracleTransportathon.WebUI.Models.User
{
    public class UserRegisterViewModel
    {
        [Display(Name ="Ad")]
        [Required(ErrorMessage ="Ad bilgisi boş geçilemez !")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad bilgisi boş geçilemez !")]
        public string Surname { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Parola bilgisi boş geçilemez !")]
        public string Password{ get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor !")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "E-Posta bilgisi boş geçilemez !")]
        public string Email { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Telefon bilgisi boş geçilemez !")]
        public string PhoneNumber { get; set; }

    }
}
