using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Application.IService
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserById(int id);
        Task<List<StatusViewModel>> GetAllStatus();
        Task<List<UserViewModel>> GetPendingUsers();
        Task UpdateUser(UserModel user);
        Task Delete(int id);
        Task<bool> IsAdmin(int userId);
    }
}
