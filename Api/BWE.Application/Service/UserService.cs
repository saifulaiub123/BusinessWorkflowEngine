using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using BWE.Domain.Constant;

namespace BWE.Application.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            var result = _mapper.Map<UserViewModel>(user);

            return result;
        }
        
        public async Task<List<StatusViewModel>> GetAllStatus()
        {
            var status = await _userRepository.GetAllStatus();
            var result = _mapper.Map<List<StatusViewModel>>(status);

            return result;
        }
        public async Task<List<UserViewModel>> GetPendingUsers()
        {
            var user = await _userRepository.GetPendingUsers();
            var result = _mapper.Map<List<UserViewModel>>(user);

            return result;
        }

        public async Task<bool> IsAdmin(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var isAdmin = (await _userManager.GetRolesAsync(user)).Where(x => x == RoleConst.ADMIN).FirstOrDefault();
            if (isAdmin != null) return true;

            return false;
        }

        public async Task UpdateUser(UserModel user)
        {
            var exist = await _userRepository.GetUserById(user.Id);
            if (exist != null)
            {
                exist.FirstName = user.FirstName;
                exist.LastName = user.LastName;
                exist.PhoneNumber = user.PhoneNumber;
                exist.Status = await _userRepository.GetStatusById(user.StatusId);
                exist.StatusId = user.StatusId;
                foreach (var existUserRole in exist.UserRoles)
                {
                    if (!user.Roles.Any(x => x == existUserRole.RoleId))
                    {
                        await _userRepository.DeleteUserRole(existUserRole);
                    }
                }
                foreach (var updateRole in user.Roles)
                {
                    if (!exist.UserRoles.Any(x => x.RoleId == updateRole))
                    {
                        await _userRepository.AddUserRole(new UserRole() { UserId = user.Id, RoleId = updateRole });
                    }
                }
                await _userManager.UpdateAsync(exist);
            }
        }
        public async Task Delete(int id)
        {
            var exist = await _userRepository.GetUserById(id);
            if (exist != null)
            {
                exist.StatusId = 0;
                await _userManager.UpdateAsync(exist);
            }
        }
    }
}
