using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Implement
{
    public class JWTService : IJwtService
    {
        private IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(UserAccount user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("AccountId", user.UserID.ToString()),
                new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "User")
            };
            var token = new JwtSecurityToken(
                  issuer: _configuration["JwtSettings:Issuer"],
                  audience: _configuration["JwtSettings:Audience"],
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:AccessTokenExpirationMinutes"])),
                  signingCredentials: creds
                );
            var tokenSign = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenSign;
        }

        public string GenerateRefreshToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            Random random = new Random();
            int length = random.Next(30, 40);
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
