using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bibliotheek.Services
{
    public interface IJwtService
    {
        JwtBearerConfig BearerConfig { get; }

        string GenerateJwt(string userId);
    }

    public class JwtService : IJwtService
    {
        public JwtService(JwtBearerConfig bearerConfig)
        {
            BearerConfig = bearerConfig;
        }

        public JwtBearerConfig BearerConfig { get; }

        public string GenerateJwt(string userId)
        {
            // Generate token for with validity of 1 day.
            var tokenHandler = new JwtSecurityTokenHandler();
            string secret = BearerConfig.Secret;
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = BearerConfig.Audience,
                Issuer = BearerConfig.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
