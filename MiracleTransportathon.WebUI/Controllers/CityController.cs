using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.CityDto;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using Newtonsoft.Json;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class CityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCityList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5125/api/City");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                return new JsonResult(JsonConvert.DeserializeObject<List<CityListDto>>(jsonData));
            }

            return Json(new { error = "Veri çekme hatası" });
        }
    }
}
