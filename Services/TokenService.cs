using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web_Api_Project.Services
{
    public class TokenService
    {
        private readonly string _secretKey = "YourSecretKey12345"; // שימי לב להשתמש במפתח סודי חזק ומאובטח
        private readonly string _validIssuer = "YourIssuer";
        private readonly string _validAudience = "YourAudience";

        public bool IsTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = _validIssuer,
                    ValidateAudience = true,
                    ValidAudience = _validAudience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // מונע חוסר דיוק של שעונים
                };

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return validatedToken is JwtSecurityToken jwtToken && jwtToken.ValidTo > DateTime.UtcNow;
            }
            catch (Exception)
            {
                // אם יש שגיאה כלשהי במהלך האימות, הטוקן לא תקף
                return false;
            }
        }

        public IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            if (!jwtHandler.CanReadToken(token))
            {
                throw new ArgumentException("Invalid JWT token format");
            }

            var jwtToken = jwtHandler.ReadJwtToken(token);
            return jwtToken.Claims;
        }
    }
}
