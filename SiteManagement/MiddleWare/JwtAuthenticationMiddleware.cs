using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SiteManagement.MiddleWare
{
    public class JwtAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                try
                {
                    var tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "SiteMangement", 
                        ValidAudience = "Admin",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKey152526")) 
                    };

                    SecurityToken validatedToken;
                    var principal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                    context.User = principal;
                }
                catch (Exception)
                {
                    
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }

            await _next(context);
        }

    }

}
