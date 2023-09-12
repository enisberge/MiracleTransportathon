using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.VehicleDto;
using MiracleTransportathon.WebUI.Models.Vehicle;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VehicleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> VehicleList()
        {
            return View();
        }       
        public async Task<IActionResult> GetVehicleList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5125/api/Vehicle");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                return new JsonResult(JsonConvert.DeserializeObject<List<VehicleListDto>>(jsonData));
            }

            return Json(new { error = "Veri çekme hatası" });
        }
       

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/Vehicle", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });

        }
        [HttpGet]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5125/api/Vehicle/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
               var vehicleDto= JsonConvert.DeserializeObject<VehicleListDto>(jsonData);

                // Başarılı olduğunu belirten isSuccess değeri ile veriyi birleştirin
                var result = new
                {
                    isSuccess = true,
                    vehicle = vehicleDto // İstediğiniz veriyi döndürebilirsiniz
                };

                return Json(result);
            }
            return Json(new { isSuccess = false });

        }


        [HttpPost]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5125/api/Vehicle", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}
