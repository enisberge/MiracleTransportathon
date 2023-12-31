﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiracleTransportathon.BusinessLayer.Concrete;
using MiracleTransportathon.DtoLayer.Dtos.LoginDto;
using MiracleTransportathon.EntityLayer.Concrete;
using System.Security.Claims;
using MiracleTransportathon.WebApi.Helper;
using System.Data;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly UserHelper _userHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager, UserHelper userHelper, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userHelper = userHelper;
            _httpContextAccessor= httpContextAccessor;

        }
        //[HttpPost]
        //public async Task<IActionResult> Login(UserLoginDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);

        //        if (result.Succeeded)
        //        {
        //            // Giriş başarılı, kullanıcıyı ana sayfaya yönlendirin veya istediğiniz sayfaya yönlendirin
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
        //        }
        //    }

        //    return Ok();
        //}
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Kullanıcı başarılı bir şekilde oturum açtığında claims ekleyebilirsiniz.
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    { string id = user.Id.ToString  ();
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, id),


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

                        // Başarılı giriş durumunda ana sayfaya yönlendirin veya istediğiniz bir sayfaya veya işleme yönlendirin.
                        return RedirectToAction("RequestList", "Request");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                }
            }

            // Başarısız giriş durumunda tekrar giriş sayfasına yönlendirin ve hata mesajlarını gösterin.
            return BadRequest(model);
        }

    }
}
