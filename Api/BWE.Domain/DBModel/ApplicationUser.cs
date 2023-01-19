using Microsoft.AspNetCore.Identity;
using System.Security;

namespace BWE.Domain.DBModel
{
    public class ApplicationUser : IdentityUser<int>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }



        //public virtual Permission CreatedByPermission { get; set; }
        //public virtual Permission? UpdatedByPermission { get; set; }

        //public virtual Server CreatedByServer { get; set; }
        //public virtual Server? UpdatedByServer { get; set; }
    }
}
