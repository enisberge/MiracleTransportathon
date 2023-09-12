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
        public IActionResult UserList()
        {
            var values = _requestService.TGetAll();
            var requestDtos = _mapper.Map<List<RequestAddDto>>(values);

            return Ok(requestDtos);
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
    }
}
