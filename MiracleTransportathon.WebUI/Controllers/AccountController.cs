using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.WebUI.Helper;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class AccountController : Controller
    {
       

        public IActionResult Login()
        {
          

            return View();
        }
    }
}
