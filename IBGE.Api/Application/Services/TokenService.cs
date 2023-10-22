using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IBGE.Api.Domain.Entities;
using IBGE.Api.Domain.Shared;
using Microsoft.IdentityModel.Tokens;

namespace IBGE.Api.Application.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSetting.Secret);
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email?.Address ?? ""),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDecriptor);
            var hash = tokenHandler.WriteToken(token);

            return hash;
        }
    }
}

