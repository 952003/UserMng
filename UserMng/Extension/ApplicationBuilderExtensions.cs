using Microsoft.AspNetCore.Builder;
using UserMng.Middlewares;

namespace UserMng.Extension
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseUserStatusValidator(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<UserStatusValidator>();
        }
    }
}
