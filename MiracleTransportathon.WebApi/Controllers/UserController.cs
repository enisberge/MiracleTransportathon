using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.EntityLayer.Concrete;
using AutoMapper;

namespace MiracleTransportathon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult UserList() {
            var values=_userService.TGetAll();
            var userDtos = _mapper.Map<List<UserListDto>>(values);

            return Ok(userDtos);
        }

        [HttpPost]
        public IActionResult AddUser(UserAddDto userDto)
        {
            if (!ModelState.IsValid ) 
            {
                return BadRequest();
            }
            var user = _mapper.Map<User>(userDto);
            _userService.TAdd(user);
            
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
           
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _mapper.Map<User>(userUpdateDto);
            _userService.TUpdateUser(user);
            return Ok("Başarıyla Güncellendi!");
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        { 
            var user=_userService.TGetById(id);
            return Ok(user);
        }
    }
}
