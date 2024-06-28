using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltroBack.Controllers.Auth
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly CuponesContext _context;
        public AuthController(CuponesContext context)
        {
            _context = context;
        }
        [HttpPost("jwt")]
        public async Task<IActionResult> login([FromBody] AuthResponse authResponse)
        {
            var token_validation = _context.MarketingUsers.FirstOrDefault(u => u.Email == authResponse.Email && u.Password == authResponse.Password);

            if (token_validation == null)
            {
                return BadRequest("The email or password isn't valid");
            }
            else
            {
                var secret_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"));
                var signin_credentials = new SigningCredentials(secret_key, SecurityAlgorithms.HmacSha256);
                var token_options = new JwtSecurityToken(
                    issuer: @Environment.GetEnvironmentVariable("jwtVar"),
                    audience: @Environment.GetEnvironmentVariable("jwtVar"),
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signin_credentials
                );
                var token_string = new JwtSecurityTokenHandler().WriteToken(token_options);

                return Ok(new { Token = token_string });
            }
            return Unauthorized();
        }
    }
}