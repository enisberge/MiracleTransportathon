using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        //[ValidateAntiForgeryToken]
        public  IActionResult Logout()
        {
            _signInManager.SignOutAsync(); // Oturumu kapat
            HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return RedirectToAction("Login", "Account"); // Kullanıcıyı başka bir sayfaya yönlendir
        }
    }
}
