using BWE.Application.IHelper;
using BWE.Application.IService;
using BWE.Domain.Constant;
using BWE.Domain.IEntity;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class ScriptHistoryController : BaseController
    {
        private readonly IScriptHistoryService _scriptHistoryService;
        private ICurrentUser _currentUser;
        private IUserService _userService;
        public ScriptHistoryController(IScriptHistoryService scriptHistoryService, ICurrentUser currentUser, IUserService userService)
        {
            _scriptHistoryService = scriptHistoryService;
            _currentUser = currentUser;
            _userService = userService;
        }

        //[HttpPost]
        //[Route("Add")]
        //public async Task<ActionResult> Add([FromBody] ScriptHistoryModel model)
        //{
        //    await _scriptHistoryService.Add(model);
        //    return Ok();
        //}

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            //bool hasPermission;
            //if (actionMode == ActionModeConst.View)
            //{
            //    hasPermission = await _scriptService.HasPermissionToView(id, _currentUser.User.Id);
            //}
            //else if (actionMode == ActionModeConst.Edit)
            //{
            //    hasPermission = await _scriptService.HasPermissionToModify(id, _currentUser.User.Id);
            //}
            //else
            //{
            //    return BadRequest();
            //}

            //if (!hasPermission) return Forbid();

            var result = await _scriptHistoryService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByUserId")]
        public async Task<ActionResult> GetByUserId([FromQuery] int userId)
        {
            var isAdmin = await _userService.IsAdmin(userId);
            if (isAdmin)
            {
                return Ok(await _scriptHistoryService.GetAll());
            }
            if (!isAdmin && _currentUser.User.Id != userId)
            {
                return Forbid();
            }
            var result = await _scriptHistoryService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
