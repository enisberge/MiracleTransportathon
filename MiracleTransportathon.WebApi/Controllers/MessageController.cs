using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.MessageDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult InboxListMessage()
        {
            var messages = _messageService.TGetAll();
            var messageDtos = _mapper.Map<List<InboxMessageDto>>(messages);
            return Ok(messageDtos);
        }

        //[HttpPost]
        //public IActionResult AddMessage(Message message)
        //{
        //    message.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
        //    _messageService.TAdd(message);
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult AddMessage(CreateMessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var message = _mapper.Map<Message>(messageDto);
            _messageService.TAdd(message);

            return Ok();
        }


        

    }
}
