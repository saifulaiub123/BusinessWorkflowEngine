using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Application.IService
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserById(int id);
        Task UpdateUser(UserModel user);
    }
}
