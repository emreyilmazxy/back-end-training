using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApp.WepApi.Jwt
{
    public static class JwtHelper
    {
        public static string GenerateJwtToken(JwtDto jwtInfo)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SecretKey));

            // Create credentials
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {

                new Claim("id", jwtInfo.Id.ToString()),
                new Claim("email", jwtInfo.Email),
                new Claim("first_name", jwtInfo.FirstName),
                new Claim("last_name", jwtInfo.LastName),
                new Claim("user_type", jwtInfo.UserType.ToString()),

                new Claim(ClaimTypes.Role, jwtInfo.UserType.ToString())
            };

            var expireTime = DateTime.Now.AddMinutes(jwtInfo.ExpireMinutes);

            var tokenDescriptor = new JwtSecurityToken(
                 issuer: jwtInfo.Issuer,
                 audience: jwtInfo.Audience,
                 claims: claims,
                 expires: expireTime,
                 signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return token;
        }
    } // end of jwthelper
}