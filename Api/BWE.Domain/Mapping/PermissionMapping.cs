using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.ViewModel;

namespace BWE.Domain.Mapping
{
    public class PermissionMapping : Profile
    {
        public PermissionMapping()
        {
            CreateMap<PermissionViewModel, Permission>()
                .ReverseMap();
        }
    }
}
