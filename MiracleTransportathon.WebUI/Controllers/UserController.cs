using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.WebUI.Models.User;
using Newtonsoft.Json;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> UserList()
        {
            return View();
        }
        //public async Task<IActionResult> GetUserList()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:5125/api/User");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var value = JsonConvert.DeserializeObject<List<UserListDto>>(jsonData);
        //        return  Json(jsonData);
        //    }

        //    return Json(new { error = "Veri çekme hatası" }); // Hata durumunda JSON hata mesajı döndür
        //}

        public async Task<IActionResult> GetUserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5125/api/User");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                return new JsonResult(JsonConvert.DeserializeObject<List<UserListDto>>(jsonData));
            }

            return Json(new { error = "Veri çekme hatası" });
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/User", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });

        }
    }
}
