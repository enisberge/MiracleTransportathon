using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.OfferDto;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService ;
        private readonly IMapper _mapper;

        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddOffer(OfferAddDto offerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var offer = _mapper.Map<Offer>(offerDto);
            _offerService.TAdd(offer);

            return Ok();
        }
    }
}
