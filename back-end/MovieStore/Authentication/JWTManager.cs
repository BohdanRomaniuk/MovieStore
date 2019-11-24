using Microsoft.IdentityModel.Tokens;
using MovieStore.AuthHelpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieStore.Authentication
{
    public class JWTManager
    {
        public static string GenerateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: JWTConfigurator.ISSUER,
                    audience: JWTConfigurator.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(JWTConfigurator.LIFETIME)),
                    signingCredentials: new SigningCredentials(JWTConfigurator.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
