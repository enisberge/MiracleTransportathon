using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.CompanyDto;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.EntityLayer.Concrete;
using MiracleTransportathon.WebUI.Models.Company;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<User> userManager, RoleManager<Role> roleManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate= DateTime.Now,

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userId = user.Id;
                    // Kullanıcı başarıyla kaydedildi, şimdi rol ataması yapabiliriz.
                    //await _userManager.AddToRoleAsync(user, "User"); // Rol adını uygun bir şekilde değiştirin

                    // Başka işlemler veya yönlendirme yapabilirsiniz
                    var roleName = (model.Role == 1) ? "User" : "Carrier";

                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        var newRole = new Role(roleName);
                        await _roleManager.CreateAsync(newRole);
                    }

                    await _userManager.AddToRoleAsync(user, roleName);
                    if (model.Role==2)
                    {
                        var newCompany = new CompanyAddDto
                        {
                            Name = model.CompanyName,
                            UserId = userId
                        };
                        var client = _httpClientFactory.CreateClient();
                        var jsonData = JsonConvert.SerializeObject(newCompany);
                        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        //var responseMessage = await client.PostAsync("http://localhost:5125/api/Company", stringContent);
                        //if (responseMessage.IsSuccessStatusCode)
                        //{
                        //    return Json(new { isSuccess = true });
                        //}

                        var apiUrl = "http://localhost:5125/api/Company/"; // API Controller'ının URL'sini belirtin

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(apiUrl, content);

                    }

                    //await _userManager.AddToRoleAsync(user, "User");

                    return Json(new { isSuccess = true });
                }
                else
                {
                    return Json(new { isSuccess = false });
                }
            }
            return Ok();
        }

    }
}
