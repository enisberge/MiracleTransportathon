using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.WebUI.Models.Offer;
using MiracleTransportathon.WebUI.Models.User;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class OfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult OfferList()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddOffer([FromBody] AddOfferViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/Offer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });

        }


    }
}
