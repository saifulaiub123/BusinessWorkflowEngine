using Microsoft.AspNetCore.Identity;

namespace BWE.Domain.DBModel
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Role Role { get; set; }
    }
}
