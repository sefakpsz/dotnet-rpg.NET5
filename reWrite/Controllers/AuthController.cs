using Microsoft.AspNetCore.Mvc;
using reWrite.Data;
using reWrite.DTOs.Character;
using reWrite.Models;
using System.Threading.Tasks;

namespace reWrite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _autho;

        public AuthController(IAuthRepository autho)
        {
            _autho = autho;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseService<string>>> Login(UserLoginDto request)
        {
            var response = await _autho.Login(request.Username, request.Password);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResponseService<int>>> Register(UserRegisterDto request)
        {
            var response = await _autho.Register(new User() { Username=request.Username},request.Password);
            if(response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

    }
}