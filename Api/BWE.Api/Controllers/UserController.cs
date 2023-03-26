using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using BWE.Application.Enum;
using BWE.Domain.IEntity;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Z.EntityFramework.Plus;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, IUserService userService, ICurrentUser currentUser = null, IMapper mapper = null)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _currentUser = currentUser;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Include(x => x.Status)
                .Where(x=> !x.IsDeleted)
                .ToListAsync();
            var result = _mapper.Map<List<UserViewModel>>(users);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetShareableUsers")]
        public async Task<IActionResult> GetShareableUsers()
        {
            var users = await _userManager.Users
                .Where(x => x.UserRoles.Any(y => y.RoleId != (int)RoleEnum.Admin))
                .Where(x => x.Id != _currentUser.User.Id)
                .ToListAsync();
            var result = _mapper.Map<List<UserViewModel>>(users);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [HttpGet]
        [Route("GetPendingUsers")]
        public async Task<IActionResult> GetPendingUsers()
        {
            var user = await _userService.GetPendingUsers();
            return Ok(user);
        }
        [HttpPatch]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
        [HttpPatch]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(_currentUser.User.Id.ToString());
            await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            var result = await _userService.GetAllStatus();
            return Ok(result);
        }
    }
}
