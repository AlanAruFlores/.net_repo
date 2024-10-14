using AutenticacionIntegradaEjemplo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AutenticacionIntegradaEjemplo.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SeguridadController : ControllerBase
    {

        /*Para acceder a un endpoint , debe estar autorizado*/
        [HttpGet]
        public IActionResult AccederEndpointSeguro()
        {
            return Ok("Este es un endpoint seguro");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, login.Usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var keyBytes  = new byte[32]; // 32 bytes = 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }

            var key = new SymmetricSecurityKey(keyBytes);
            var credenciales = new SigningCredentials(key, "pG9V1a9kZxV9e9H2FJasZw==");

            var token = new JwtSecurityToken(
                issuer: "MiIssuerAca",
                audience: "https://localhost:7037/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credenciales
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
    