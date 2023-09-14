using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult RequestList()
        {
            var values = _requestService.GetAllRequest();
            //var requestDtos = _mapper.Map<List<RequestAddDto>>(values);

            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRequest(RequestAddDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var request = _mapper.Map<Request>(requestDto);
            _requestService.TAdd(request);

            return Ok();
        }

        [HttpGet("{requestId}")]
        public IActionResult GetRequestById(int requestId)
        {
            var values = _requestService.GetRequestById(requestId);

            return Ok(values);
        }
    }
}
