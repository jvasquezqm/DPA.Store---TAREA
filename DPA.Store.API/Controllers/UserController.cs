using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("Registrar usuario")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            var result = await _userRepository.RegisterUser(user);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("Login usuario")]
        public async Task<IActionResult> LoginUser(String correo, String password)
        {
            var result = await _userRepository.Login(correo, password);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _userRepository.Eliminar(id);
            if (!result)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
