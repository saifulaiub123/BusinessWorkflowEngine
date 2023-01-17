using BWE.Application.Response;
using BWE.Domain.Model;

namespace BWE.Application.IService
{
    public interface IOtpService
    {
        Task SendOtp(string mobileNumber);
        Task<OtpResponse> VerifyOtp(VerifyOtp verifyOtp);
    }
}
