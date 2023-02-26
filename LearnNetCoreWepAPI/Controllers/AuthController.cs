using LearnNetCoreWepAPI.Authorization.Helpers.Interfaces;
using LearnNetCoreWepAPI.Authorization.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnNetCoreWepAPI.Controllers
{
 

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Result=await this._authService.Register(registerModel);
            if(!Result.IsAuthenticated)
            {
                return BadRequest(Result.Message);
            }


            return Ok(Result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Result = await this._authService.Login(loginModel);
            if (!Result.IsAuthenticated)
            {
                return BadRequest(Result.Message);
            }


            return Ok(Result);
        }

    }
}