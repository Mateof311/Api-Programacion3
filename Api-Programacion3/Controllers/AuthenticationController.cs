using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthenticationController(IConfiguration config, ICustomAuthenticationService authenticateService)
        {
            _config = config;
            _customAuthenticationService = authenticateService;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] CredentialsRequest credentials)
        {
            string? token = _customAuthenticationService.Authenticate(credentials);
            if (token is not null)
            {
                return Ok(token);
            }
            
            return Unauthorized(new { message = "Credenciales inválidas. Por favor, verificar email y contraseña." });
        }
    }
}
