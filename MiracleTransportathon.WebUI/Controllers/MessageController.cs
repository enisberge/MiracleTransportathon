using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.DtoLayer.Dtos.MessageDto;
using MiracleTransportathon.WebUI.Models.Message;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace MiracleTransportathon.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> MessageList()
        {
            return View();
        }
        public async Task<IActionResult> Inbox()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:5125/api/Message");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<InboxMessageDto>>(jsonData);
            //return View(values);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5125/api/Message");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxMessageDto>>(jsonData);
                //return new JsonResult(JsonConvert.DeserializeObject<List<InboxMessageDto>>(jsonData));
                return View(values);
            }

            return Json(new { error = "Veri çekme hatası" });
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage([FromBody] CreateMessageDto createMessageDto)
        {
            //createMessageDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5125/api/Message", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });

        }
        [HttpGet]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5125/api/Message/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var messageDto = JsonConvert.DeserializeObject<InboxMessageDto>(jsonData);

                // Başarılı olduğunu belirten isSuccess değeri ile veriyi birleştirin
                var result = new
                {
                    isSuccess = true,
                    message = messageDto // İstediğiniz veriyi döndürebilirsiniz
                };

                return Json(result);
            }
            return Json(new { isSuccess = false });

        }


        [HttpPost]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5125/api/Message", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }

}
