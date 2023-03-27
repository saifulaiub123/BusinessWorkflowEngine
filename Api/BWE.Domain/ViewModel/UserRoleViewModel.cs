
namespace BWE.Domain.ViewModel
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public RoleViewModel Role { get; set; }
    }
}
