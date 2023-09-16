using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.WebUI.Helper;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly UserHelper _userHelper;

        public AdminLayoutController(UserHelper userHelper)
        {
            _userHelper = userHelper;
        }
        public IActionResult _AdminLayout()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult PreLoaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavHeaderPartial()
        {
            ViewBag.UserRole = _userHelper.GetCurrentRole();
            return PartialView(ViewBag);
        }
        public PartialViewResult SideBarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
