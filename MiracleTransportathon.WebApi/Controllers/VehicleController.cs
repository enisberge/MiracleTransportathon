using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult VehicleList()
        {
            var vehicles = _vehicleService.TGetAll();
            return Ok(vehicles);
        }

        [HttpPost]
        public IActionResult AddVehicle()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteVehicle()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateVehicle()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetVehicle()
        {
            return Ok();
        }
    }
}
