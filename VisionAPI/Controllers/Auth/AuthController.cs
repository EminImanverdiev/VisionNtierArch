using Business.Services.Abstract;
using Entities.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VisionAPI.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var result= await _service.Register(register);

            if (!result.Success)
            {
                return  BadRequest(result.Message);

            }

            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _service.Login(login);
            if (!result.Success)
            {
                return BadRequest(result.Message);
               
            }
            return Ok(result);

        }



       [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("add-admin")]
        public async Task<IActionResult> AddAdmin(RegisterDto register)
        {
            var admin = await _service.AddAdmin(register);
            if (!admin.Success)
            {
                return BadRequest(admin.Message);
            }
            return Ok();
        }
    }
}
