using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Abigo.JWTAdmin
{

    public class AdminToken
        {
            public byte[] key { get; set; } = Encoding.ASCII.GetBytes("4e594798-6867-4dff-887a-9a7c12882b8e");

            public string Generate(TokenPayload payload)
            {
                var handler = new JwtSecurityTokenHandler();
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var ci = new ClaimsIdentity();
                ci.AddClaim(new Claim(ClaimTypes.Email, payload.AccountConnectionEmail));
                ci.AddClaim(new Claim(ClaimTypes.Authentication, payload.AccountId));
                ci.AddClaim(new Claim(ClaimTypes.Name, payload.AccountName));


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = ci,
                    SigningCredentials = credentials,
                    Expires = DateTime.UtcNow.AddDays(2)
                };

                var token = handler.CreateToken(tokenDescriptor);
                var tokenString = handler.WriteToken(token);
                return tokenString;

            }

            public bool ValidateToken(string token)
            {
                var handler = new JwtSecurityTokenHandler();

                SecurityToken validatedToken;
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateLifetime = false, // Because there is no expiration in the generated token
                    ValidateAudience = false, /// Because there is no expiration in the generated token
                    ValidateIssuer = false,   // Because there is no issuer in the generated token
                    ValidIssuer = "Sample",
                    ValidAudience = "Sample",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out validatedToken);

                return true;
            }
            public TokenPayload DecodeToken(string token)
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                try
                {
                    SecurityToken validatedToken;
                    var principal = handler.ValidateToken(token, validationParameters, out validatedToken);

                    var accountId = principal.FindFirst(ClaimTypes.Authentication)?.Value ?? string.Empty;
                    var accountAccessEmail = principal.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
                    var accountName = principal.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

                    return new TokenPayload
                    {
                        AccountId = accountId,
                        AccountConnectionEmail = accountAccessEmail,
                        AccountName = accountName
                    };
                }
                catch
                {
                    // Token validation failed
                    throw new UnauthorizedAccessException("invalid token");
                }
            }
        }
    }

