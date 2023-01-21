using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserService _userService;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }


        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).Where(x => x.Status == 1).ToListAsync();
            return Ok(users);
        }
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [HttpPatch]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpPatch]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(changePasswordModel.Id.ToString());
            await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            return Ok();
        }
    }
}
