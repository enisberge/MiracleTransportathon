using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.CompanyDto;
using MiracleTransportathon.WebUI.Models.Company;
using Newtonsoft.Json;
using System.Text;

namespace MiracleTransportathon.WebUI.Controllers
{
    public class CompanyController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CompanyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CompanyList()
        {
            return View();
        }
        public async Task<IActionResult> GetCompanyList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5125/api/Company");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                return new JsonResult(JsonConvert.DeserializeObject<List<CompanyListDto>>(jsonData));
            }

            return Json(new { error = "Veri çekme hatası" });
        }


        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/Company", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });

        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5125/api/Company/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var companyDto = JsonConvert.DeserializeObject<CompanyListDto>(jsonData);

                // Başarılı olduğunu belirten isSuccess değeri ile veriyi birleştirin
                var result = new
                {
                    isSuccess = true,
                    company = companyDto // İstediğiniz veriyi döndürebilirsiniz
                };

                return Json(result);
            }
            return Json(new { isSuccess = false });

        }


        [HttpPost]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5125/api/Company", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}

