using BWE.Domain.DBModel;
using BWE.Domain.ViewModel;

namespace BWE.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserById(int id);
        Task<List<ApplicationUser>> GetPendingUsers();
        Task DeleteUserRole(UserRole userRole);
        Task AddUserRole(UserRole userRole);
        Task UpdateUserRole(UserRole userRole);
        //Task UpdateUser(ApplicationUser user);
    }
}
