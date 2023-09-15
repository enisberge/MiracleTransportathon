using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.EntityLayer.Concrete;
using MiracleTransportathon.WebUI.Models;
using MiracleTransportathon.WebUI.Models.User;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register()
        {

            return View();  
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/Register", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}