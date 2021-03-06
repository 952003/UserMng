using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UserMng.Identity;
using UserMng.Interfaces;

namespace UserMng.Middlewares
{
    public class UserStatusValidator
    {
        private readonly RequestDelegate _next;

        public UserStatusValidator(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IdentityDBContext dbContext, IIdentityUnitOfWork identityUnitOfWork)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var user = await identityUnitOfWork.UserManager.GetUserAsync(context.User);
                if(user == null || user.IsBlocked == true)
                {
                    await identityUnitOfWork.SignInManager.SignOutAsync();
                    context.Response.Redirect("/Account/Exception");
                }
            }
            await _next.Invoke(context);
        }
    }
}
