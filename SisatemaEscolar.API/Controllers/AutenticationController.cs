using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SistemaEscolar.Domain.Entities;
using SisatemaEscolar.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SisatemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    public class AutenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        public AutenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("Logar")]
        [HttpPost]
        public IActionResult Logar([FromBody] Autenticacao autenticacao)
        {
            return Ok(GenerateToken(autenticacao));
        }

        [HttpGet]
        [Authorize]
        [Route("Teste")]
        public IActionResult Teste()
        {
            return Ok(_configuration["Jwt:SecretKey"]);
        }



        #region Metodos
        private TokenValidate GenerateToken(Autenticacao userInfo)
        {
            //declarações do usuário
            var claims = new[]
            {
                new Claim("Login",userInfo.Login ),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //gerar a assinatura digital
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //definir o tempo de expiração
            var expiration = DateTime.UtcNow.AddHours(2);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audiencia
                audience: _configuration["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiracao
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
                );

            return new TokenValidate()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                HorarioValidade = expiration
            };
        }
        #endregion
    }
}
