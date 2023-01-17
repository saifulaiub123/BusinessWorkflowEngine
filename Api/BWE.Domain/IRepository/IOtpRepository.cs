using BWE.Domain.DBModel;

namespace BWE.Domain.IRepository
{
    public interface IOtpRepository : IRepository<Otp, int>
    {
        Task<Otp> GetLatestOtp(string mobileNumber);
    }
}
