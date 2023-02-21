using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace BWE.Api.Authentication
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            throw new NotImplementedException();
        }
    }
}
