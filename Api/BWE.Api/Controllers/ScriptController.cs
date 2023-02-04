using BWE.Application.IService;
using BWE.Domain.Constant;
using BWE.Domain.IEntity;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class ScriptController : BaseController
    {
        private readonly IScriptService _scriptService;
        private readonly IScriptUserPermissionService _scriptUserPermissionService;
        private readonly IUserService _usrService;
        private readonly ICurrentUser _currentUser;
        public ScriptController(IScriptService scriptService, ICurrentUser currentUser, IUserService usrService, IScriptUserPermissionService scriptUserPermissionService)
        {
            _scriptService = scriptService;
            _currentUser = currentUser;
            _usrService = usrService;
            _scriptUserPermissionService = scriptUserPermissionService;
        }

        [HttpPost]
        [Route("AddScript")]
        public async Task<ActionResult> AddScript([FromBody] ScriptModel model)
        {
            await _scriptService.AddScript(model);
            return Ok();
        }

        [HttpGet]
        [Route("GetScriptById")]
        public async Task<ActionResult> GetScriptById([FromQuery] int id,string actionMode)
        {
            bool hasPermission;
            if (actionMode == ActionModeConst.View)
            {
                hasPermission = await _scriptService.HasPermissionToView(id, _currentUser.User.Id);
            }
            else if(actionMode == ActionModeConst.Edit)
            {
                hasPermission = await _scriptService.HasPermissionToModify(id, _currentUser.User.Id);
            }
            else
            {
                return BadRequest();
            }
            
            if (!hasPermission) return Forbid();

            var result = await _scriptService.GetScriptById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetScriptsByUserId")]
        public async Task<ActionResult> GetScriptsByUserId([FromQuery]int userId)
        {
            var isAdmin = await _usrService.IsAdmin(userId);
            if(isAdmin)
            {
                return Ok(await _scriptService.GetAll());
            }
            if(!isAdmin && _currentUser.User.Id != userId)
            {
                return Forbid();
            }
            var result = await _scriptService.GetScriptsByUserId(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSharedScriptsByUserId")]
        public async Task<ActionResult> GetSharedScriptsByUserId([FromQuery] int userId)
        {
            var isAdmin = await _usrService.IsAdmin(userId);
            if (!isAdmin && _currentUser.User.Id != userId)
            {
                return Forbid();
            }
            var result = await _scriptService.GetSharedScriptsByUserId(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetScriptSharedUser")]
        public async Task<ActionResult> GetScriptSharedUser([FromQuery] int scriptId)
        {
            var script = await _scriptService.GetScriptById(scriptId);
            var scriptUserPermission = await _scriptUserPermissionService.GetScriptUserPermissionsByScriptId(scriptId);

            var isAdmin = await _usrService.IsAdmin(_currentUser.User.Id);
            if (isAdmin || _currentUser.User.Id == script.CreatedBy)
            {
                var result = await _scriptService.GetScriptSharedUser(scriptId);
                return Ok(result);
            }
            else if(scriptUserPermission.Any(x => x.UserId == _currentUser.User.Id && x.ScriptId == scriptId))
            {
                return Ok(new List<SharedScriptUserViewModel>());
            }

            return Forbid();
            
        }

        [HttpPatch]
        [Route("UpdateScript")]
        public async Task<ActionResult> UpdateScript([FromBody] UpdateScriptModel script)
        {
            var hasPermission = await _scriptService.HasPermissionToModify((int)script.Id, _currentUser.User.Id);
            if(!hasPermission)
            {
                return Forbid();
            }

            await _scriptService.UpdateScript(script);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteScript")]
        public async Task<ActionResult> DeleteScript([FromQuery] int id)
        {
            var hasPermission = await _scriptService.HasPermissionToModify((int)id, _currentUser.User.Id);
            if (!hasPermission)
            {
                return Forbid();
            }
            await _scriptService.DeleteScript(id);
            return Ok();
        }

    }
}
