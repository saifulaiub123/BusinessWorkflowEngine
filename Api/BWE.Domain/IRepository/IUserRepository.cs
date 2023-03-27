using BWE.Domain.DBModel;

namespace BWE.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserById(int id);
        Task<List<Status>> GetAllStatus();
        Task<Status> GetStatusById(int id);
        Task<List<ApplicationUser>> GetPendingUsers();
        Task DeleteUserRole(UserRole userRole);
        Task AddUserRole(UserRole userRole);
        Task UpdateUserRole(UserRole userRole);
    }
}
