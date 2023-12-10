using BookStore.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Services
{
    public class TokenManager
    {
        private TokenOptions _options;
        public TokenManager() => _options = new TokenOptions { Secret = "chavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquer", ExpiresDay = 1 };
        public string Generate(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            claims.AddClaim(new Claim("name", user.Name));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Secret)),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                Expires = DateTime.Now.AddDays(_options.ExpiresDay)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
