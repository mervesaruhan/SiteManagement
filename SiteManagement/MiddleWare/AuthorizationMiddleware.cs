using System.Net;
using System.Security.Claims;

namespace SiteManagement.MiddleWare
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {


           
            var user = context.User;

            
            if (user == null || !user.Identity.IsAuthenticated || !user.Identity.Name.Equals("Admin"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Yetkisiz erişim.");
                return;
            }




            await _next(context);
        }
    }

}
