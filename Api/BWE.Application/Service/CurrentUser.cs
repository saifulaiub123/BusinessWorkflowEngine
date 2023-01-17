using BWE.Domain.Constant;
using BWE.Domain.IEntity;
using BWE.Domain.DBModel;
using Microsoft.AspNetCore.Http;

namespace BWE.Application.Service
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;
        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public ApplicationUser User => new ApplicationUser()
        {
            Id = Convert.ToInt32(_accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.Id)?.Value),
            UserName = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.UserName)
                ?.Value,
            NormalizedUserName = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.Name)
                ?.Value,
            Email = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConstant.Email)?.Value
        };

    }
}

