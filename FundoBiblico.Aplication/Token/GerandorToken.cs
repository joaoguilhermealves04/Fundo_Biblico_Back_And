using FundoBiblico.Dominio.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Token
{

    public class TokenGenerator
    {
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenGenerator(string key, string issuer, string audience)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _issuer = issuer;
            _audience = audience;
        }

        public string GenerateToken(Usuario user, int expiresInSeconds)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _key;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _issuer,
                Audience = _audience,
                Claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Expired, DateTime.UtcNow.AddHours(8)))
                }
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
