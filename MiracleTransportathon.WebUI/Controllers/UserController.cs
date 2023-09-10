using Microsoft.AspNetCore.Mvc;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
