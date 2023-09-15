using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.LoginDto;
using MiracleTransportathon.DtoLayer.Dtos.UserDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
     
        public RegisterController(IUserService userService, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    PhoneNumber= model.PhoneNumber


                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Kullanıcı başarıyla kaydedildi, şimdi rol ataması yapabiliriz.
                    //await _userManager.AddToRoleAsync(user, "User"); // Rol adını uygun bir şekilde değiştirin

                    // Başka işlemler veya yönlendirme yapabilirsiniz


                    var roleExists = await _roleManager.RoleExistsAsync("User");

                    if (!roleExists)
                    {
                        var newRole = new Role("User");
                        await _roleManager.CreateAsync(newRole);
                    }


                    await _userManager.AddToRoleAsync(user, "User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok();
        }


       
    }
}
