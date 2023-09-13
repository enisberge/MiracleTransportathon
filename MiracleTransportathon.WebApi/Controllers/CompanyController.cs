using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.CompanyDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CompanyList()
        {
            var companies = _companyService.TGetAll();
            var companyDtos = _mapper.Map<List<CompanyListDto>>(companies);
            return Ok(companyDtos);
        }


        [HttpPost]
        public IActionResult AddCompany(CompanyAddDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var company = _mapper.Map<Company>(companyDto);
            _companyService.TAdd(company);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);

            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCompany(CompanyUpdateDto companyUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var company = _mapper.Map<Company>(companyUpdateDto);
            _companyService.TUpdateCompany(company);
            return Ok("Başarıyla Güncellendi!");
        }
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companyService.TGetById(id);
            return Ok(company);
        }
    }
}
