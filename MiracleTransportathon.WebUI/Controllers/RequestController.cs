using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.WebUI.Models.Request;
using MiracleTransportathon.WebUI.Models.User;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class RequestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> RequestList()
        {
            return View();
        }

        public async Task<IActionResult> AddRequestPage()
        {
            return View();
        }
        public async Task<IActionResult> GetRequestList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5125/api/Request");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                return new JsonResult(JsonConvert.DeserializeObject<List<RequestListDto>>(jsonData));
            }

            return Json(new { error = "Veri çekme hatası" });
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] AddRequestViewModel model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/Request", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });

        }

        [HttpGet]
        public async Task<IActionResult> GetRequestById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5125/api/Request/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var requestDto = JsonConvert.DeserializeObject<RequestListDto>(jsonData);



                // Başarılı olduğunu belirten isSuccess değeri ile veriyi birleştirin
                var result = new
                {
                    isSuccess = true,
                    request = requestDto // İstediğiniz veriyi döndürebilirsiniz
                };

                return Json(result);
            }
            return Json(new { isSuccess = false });

        }
    }
}
