using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Secure")]
    public class SecureController : Controller
    {
        private readonly MeuContext _context;

        public SecureController(MeuContext context)
        {
            _context = context;
        }

        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            return Ok($"Conteudo super secreto");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] TokenRequest request)
        {

            var usuarioModel = await _context.UsuarioModel
                .SingleOrDefaultAsync(m => m.UserName == request.Username);
            if (usuarioModel == null)
            {
                return BadRequest("Usuario nao encontrado.");
            }


            string senha = HashCalculator.GenerateMD5(request.Password);


            if (senha == usuarioModel.Senha)
            {


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Usuario e senha incorretos.");
        }

    }


}