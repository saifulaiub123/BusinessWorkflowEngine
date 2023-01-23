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
        [Route("GetScriptById")]
        public async Task<ActionResult> GetScriptById([FromQuery] int id)
        {
            var result = await _scriptService.GetScriptById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetScriptsByUserId")]
        public async Task<ActionResult> GetScriptsByUserId([FromQuery]int userId)
        {
            var result = await _scriptService.GetScriptsByUserId(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSharedScriptsByUserId")]
        public async Task<ActionResult> GetSharedScriptsByUserId([FromQuery] int userId)
        {
            var result = await _scriptService.GetSharedScriptsByUserId(userId);
            return Ok(result);
        }

        [HttpPatch]
        [Route("UpdateScript")]
        public async Task<ActionResult> UpdateScript([FromBody] ScriptModel script)
        {
            await _scriptService.UpdateScript(script);
            return Ok();
        }

    }
}
