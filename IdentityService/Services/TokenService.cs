using IdentityService.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string CreateToken(User user)
        {
            string tokenKey = _config["jwtTokenKey"];

            // create claim list from user object
            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // key and signing credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha384Signature);

            // token descriptor 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
