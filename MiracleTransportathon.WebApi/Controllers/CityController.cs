using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.CityDto;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CityList()
        {
            var values = _cityService.TGetAll();
            var citiesDtos = _mapper.Map<List<CityListDto>>(values);

            return Ok(citiesDtos);
        }
    }
}
