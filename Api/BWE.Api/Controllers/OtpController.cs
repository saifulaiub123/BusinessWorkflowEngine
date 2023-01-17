using BWE.Application.IService;
using BWE.Domain.IEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BWE.Domain.Model;
using Serilog;

namespace BWE.Api.Controllers
{
    
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;
        private readonly ICurrentUser _currentUser;

        public OtpController(IOtpService otpService, ICurrentUser currentUser)
        {
            _otpService = otpService;
            _currentUser = currentUser;
        }

        [HttpGet("SendOtp")]
        public async Task SendOtp([FromQuery] string mobileNumber)
        {
            try
            {
                await _otpService.SendOtp(mobileNumber);
                throw new Exception("Error");
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        [HttpGet("VerifyOtp")]
        public async Task VerifyOtp([FromQuery] VerifyOtp verifyOtp)
        {
            try
            {
                Log.Information("Perfect");
                await _otpService.VerifyOtp(verifyOtp);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok("Ok");
        }
        [HttpGet("TestApi")]
        public async Task<IActionResult> TestApi()
        {
            return Ok("Ok");
        }
    }
}
