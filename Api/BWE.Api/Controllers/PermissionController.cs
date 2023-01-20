using BWE.Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BWE.Api.Controllers
{
    [Authorize]
    public class PermissionController : BaseController
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("GetAllPermission")]
        public async Task<IActionResult> GetAllPermission()
        {
            var data = await _permissionService.GetAllPermission();
            return Ok(data);
        }
    }
}
