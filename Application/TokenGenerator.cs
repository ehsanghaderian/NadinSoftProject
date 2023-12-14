using DomainModel.Users;
using Infrastructure.Appsettings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JwtSetting _jwtSetting;
        public TokenGenerator(IOptions<JwtSetting> jwtSetting)
        {
            this._jwtSetting = jwtSetting.Value;
        }

        public string Generate(User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim("username", user.UserName),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("userid", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("phonenumber", user.PhoneNumber),
                    new Claim("jwtid", Guid.NewGuid().ToString()),
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));

            var token = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.ValidTime),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
