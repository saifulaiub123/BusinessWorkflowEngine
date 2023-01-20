using BWE.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BWE.Api.Controllers
{
    public class ScriptController : BaseController
    {
        public ScriptController()
        {
        }

        [HttpPost("AddScript")]
        public async Task<ActionResult> AddScript([FromBody] ScriptModel model)
        {

            return Ok();
        }
    }
}
