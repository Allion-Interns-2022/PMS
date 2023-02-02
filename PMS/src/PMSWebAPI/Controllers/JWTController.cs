using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly PMSContext _context;
        public JWTController(IConfiguration configuration, PMSContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user != null && user.Username != null && user.Password != null)
            {
                var userData = await GetUser(user.Username, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                if (userData != null && userData.Id != 0)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Username", user.Username),
                        new Claim("Password", user.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken 
                        (
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires:DateTime.Now.AddMinutes(20),
                            signingCredentials:signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }

        [HttpGet]
        public async Task<User> GetUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
