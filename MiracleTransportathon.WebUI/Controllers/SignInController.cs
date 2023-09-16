using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.LoginDto;
using MiracleTransportathon.EntityLayer.Concrete;
using MiracleTransportathon.WebUI.Helper;
using System.Security.Claims;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly UserHelper _userHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SignInController(SignInManager<User> signInManager, UserManager<User> userManager, UserHelper userHelper, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userHelper = userHelper;
            _httpContextAccessor = httpContextAccessor;
        }
        //}
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Kullanıcı başarılı bir şekilde oturum açtığında claims ekleyebilirsiniz.
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        string id = user.Id.ToString();
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Surname,user.Surname),


                    // İhtiyaca göre diğer claims'leri ekleyebilirsiniz.
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(principal);
                        //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //var principal = new ClaimsPrincipal(identity);
                        var roles = await _userManager.GetRolesAsync(user);
                        var userRole = roles.FirstOrDefault(); // İlk rolü alabilirsiniz
                        // HttpContext.SignInAsync() ile claims ekleyerek oturum açabilirsiniz.
                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        _httpContextAccessor.HttpContext.Session.SetString("UserRole", userRole);

                        var userid = _userHelper.GetCurrentUserId();
                        // HttpContext.SignInAsync() ile claims ekleyerek oturum açabilirsiniz.
                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);



                        // Başarılı giriş durumunda ana sayfaya yönlendirin veya istediğiniz bir sayfaya veya işleme yönlendirin.
                        return Json(new { isSuccess = true });
                    }
                }
                else
                {
                    return Json(new { isSuccess = false });
                }
            }

            // Başarısız giriş durumunda tekrar giriş sayfasına yönlendirin ve hata mesajlarını gösterin.
            return Json(new { isSuccess = false });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
