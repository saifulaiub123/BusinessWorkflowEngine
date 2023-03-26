using Microsoft.AspNetCore.Identity;
using System.Security;

namespace BWE.Domain.DBModel
{
    public class ApplicationUser : IdentityUser<int>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<ScriptUserPermission>? ScriptUserPermissions { get; set; }


        public virtual Status Status { get; set; }

        public virtual Permission CreatedByPermission { get; set; }
        public virtual Permission? UpdatedByPermission { get; set; }

        public virtual Server CreatedByServer { get; set; }
        public virtual Server? UpdatedByServer { get; set; }

        public virtual Script CreatedByScript { get; set; }
        public virtual Script? UpdatedByScript { get; set; }

        public virtual ScriptUserPermission CreatedByScriptUserPermission { get; set; }
        public virtual ScriptUserPermission? UpdatedByScriptUserPermission { get; set; }

        public virtual ScriptHistory CreatedByScriptHistory { get; set; }
        public virtual ScriptHistory? UpdatedByScriptHistory { get; set; }


    }
}
