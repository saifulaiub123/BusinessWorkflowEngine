using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.ViewModel;

namespace BWE.Domain.Mapping
{
    public class OtpMapping : Profile
    {
        public OtpMapping()
        {
            CreateMap<OtpViewModel,Otp>()
                .ReverseMap();
        }
    }
}
