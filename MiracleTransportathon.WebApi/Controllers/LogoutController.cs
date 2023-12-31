﻿using Microsoft.AspNetCore.Authentication;
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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Oturumu kapat
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return RedirectToAction("RequestList", "Request"); // Kullanıcıyı başka bir sayfaya yönlendir
        }
    }
}
