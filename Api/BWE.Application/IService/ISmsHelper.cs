namespace BWE.Application.IService
{
    public interface ISmsHelper
    {
        Task<int> SendSms(string mobileNumber);
    }
}
