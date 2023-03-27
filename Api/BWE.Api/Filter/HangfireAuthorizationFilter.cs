using BWE.Api.Authentication;
using Hangfire.Dashboard;

namespace BWE.Api.Filter
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        private string role;
        public HangfireAuthorizationFilter(string role = null)
        {
            this.role = role;
        }

        public bool Authorize(DashboardContext context)
        {
            var queryKey = "token";
            var accessToken = String.Empty;

            var httpContext = context.GetHttpContext();
            var referer = httpContext.Request.Headers["Referer"].FirstOrDefault();
            if (referer != null && referer.Contains(queryKey))
            {
                accessToken = referer.Substring(referer.IndexOf(queryKey, StringComparison.Ordinal) + queryKey.Length + 1);
            }
            else if (httpContext.Request.Query.ContainsKey(queryKey))
            {
                accessToken = httpContext.Request.Query[queryKey].FirstOrDefault();
            }
            
            if (String.IsNullOrEmpty(accessToken)) return false;

            var jwtFactory = httpContext.RequestServices.GetService(typeof(TokenHelper)) as TokenHelper;
            //var userManager = httpContext.RequestServices.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
            var userRoles = jwtFactory.ValidateToken(accessToken).ConfigureAwait(false).GetAwaiter().GetResult();
            if (userRoles == null) return false;

            //var user = userManager.FindByIdAsync(userId.ToString()).ConfigureAwait(false).GetAwaiter().GetResult();
            //var userRoles = userManager.GetRolesAsync(user).ConfigureAwait(false).GetAwaiter().GetResult();
            if (userRoles.Count == 0 || !userRoles.Any(x=> x.Contains(this.role)))
            {
                return false;
            }
            return true;
        }
    }
}