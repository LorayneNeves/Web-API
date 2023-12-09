using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using AutoMapper;
using Data.Repository;
using Domain.Entities;
using Domain.Interface;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper,
             ITokenService tokenService, IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _tokenService = tokenService;
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _usuarioRepository.Autenticar(model.Login, model.Senha);

            if (token == null)
            {
                return Unauthorized(); // Ou qualquer código de erro que você deseja retornar
            }

            return Ok(new { Token = token });
        }


        private string GerarTokenJwt(Usuario usuario)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        new Claim(ClaimTypes.Name, usuario.Login),
        // Adicione outras claims conforme necessário
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30), // Defina o tempo de expiração do token
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
