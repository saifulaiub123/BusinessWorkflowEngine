using BWE.Application.Enum;

namespace BWE.Application.Response
{
    public class OtpResponse
    {
        public OtpResponse()
        {}

        public OtpResponse(OtpResponseEnum status, string message)
        {
            Status = status;
            Message = message;
        }

        public OtpResponseEnum Status { get; set; }
        public string Message { get; set; }
    }
}
