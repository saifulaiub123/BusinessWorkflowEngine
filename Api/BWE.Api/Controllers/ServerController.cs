using BWE.Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class ServerController : BaseController
    {
        private readonly IServerService _serverService;

        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpGet("GetAllServer")]
        public async Task<IActionResult> GetAllServer()
        {
           var data = await _serverService.GetAllServer();
           return Ok(data);
        }
    }
}
