using BWE.Application.IService;
using BWE.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class ScriptController : BaseController
    {
        private readonly IScriptService _scriptService;
        public ScriptController(IScriptService scriptService)
        {
            _scriptService = scriptService;
        }

        [HttpPost]
        [Route("AddScript")]
        public async Task<ActionResult> AddScript([FromBody] ScriptModel model)
        {
            await _scriptService.AddScript(model);
            return Ok();
        }

        [HttpGet]
        [Route("GetScriptsByUserId")]
        public async Task<ActionResult> GetScriptsByUserId(int userId)
        {
            var result = await _scriptService.GetScriptsByUserId(userId);
            return Ok(result);
        }
    }
}
