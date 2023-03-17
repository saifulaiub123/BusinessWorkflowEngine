
namespace BWE.Domain.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public List<UserRoleViewModel> UserRoles { get; set; }
    }
}
