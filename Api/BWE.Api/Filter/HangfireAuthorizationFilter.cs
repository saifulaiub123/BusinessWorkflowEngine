using BWE.Api.Authentication;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;

namespace BWE.Api.Filter
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {

        private static readonly string HangFireCookieName = "HangFireCookie";

        private string role;
        public HangfireAuthorizationFilter(string role = null)
        {
            this.role = role;
        }

        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var jwtFactory = httpContext.RequestServices.GetService(typeof(TokenHelper)) as TokenHelper;
            var access_token = httpContext.Request.Cookies[HangFireCookieName];

            if (String.IsNullOrEmpty(access_token))
            {
                return false;
            }

            try
            {
                var principal = jwtFactory.ValidateToken(access_token);
                if (!String.IsNullOrEmpty(this.role))
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return true;
        }
    }
}