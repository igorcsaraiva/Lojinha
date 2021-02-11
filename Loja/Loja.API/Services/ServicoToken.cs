using Loja.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Loja.API.Services
{
    public class ServicoToken
    {
        private readonly IConfiguration _configuration;
        public ServicoToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(UsuarioViewModel clienteViewModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, clienteViewModel.Codigo.ToString()),
                    new Claim(ClaimTypes.Role, clienteViewModel.Codigo.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
