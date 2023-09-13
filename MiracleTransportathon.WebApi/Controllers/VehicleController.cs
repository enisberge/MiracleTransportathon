using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.VehicleDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;
        public VehicleController(IVehicleService vehicleService,IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult VehicleList()
        {
            var vehicles = _vehicleService.TGetAll();
            var vehicleDtos = _mapper.Map<List<VehicleListDto>>(vehicles);
            return Ok(vehicleDtos);
        }

        [HttpPost]
        public IActionResult AddVehicle(VehicleAddDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            _vehicleService.TAdd(vehicle);

            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteVehicle(int id)
        {
            _vehicleService.DeleteVehicle(id);

            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateVehicle(VehicleUpdateDto vehicleUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var vehicle = _mapper.Map<Vehicle>(vehicleUpdateDto);
            _vehicleService.TUpdateVehicle(vehicle);
            return Ok("Başarıyla Güncellendi!");
        }
        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = _vehicleService.TGetById(id);
            return Ok(vehicle);
        }
    }
}
