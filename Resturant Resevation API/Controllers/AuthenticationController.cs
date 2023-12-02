using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MinimalASP.NETWebAPI;

namespace MinimalASP.NETWebAPI.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        // we won't use this outside of this class, so we can scope it to this namespace
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }

        }

        private readonly JwtTokenGenerator _tokenGenerator;
        private string _token = "";
        public AuthenticationController(IConfiguration configuration)
        {
            _tokenGenerator = new JwtTokenGenerator(configuration);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var token = _tokenGenerator
                .GenerateToken(authenticationRequestBody.UserName!, authenticationRequestBody.Password!);
            _token = token;

            if (token != null)
            {
                return Ok(token);
            }

            return Unauthorized();
        }

        [HttpGet("validate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ValidateToken()
        {
            if(_tokenGenerator.ValidateToken(_token))
                return Ok(new { Message = "Token is valid." });

            return BadRequest("Invalid token");
        }
    }
}
