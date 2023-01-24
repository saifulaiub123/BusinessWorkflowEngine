using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Domain.Mapping
{
    public class ScriptMapping : Profile
    {
        public ScriptMapping()
        {
            CreateMap<Script,ScriptModel>().ReverseMap();
            CreateMap<Script,ScriptViewModel>()
                .ForMember(a => a.DestinationServerName, b => b.MapFrom(b => b.Server.Name))
                .ForMember(a => a.UserName, b => b.MapFrom(b => b.CreatedByUser.Email));

            CreateMap<ScriptUserPermission, ScriptUserPermissionModel>().ReverseMap();
            CreateMap<ScriptUserPermission, SharedScriptUserViewModel>()
                .ForMember(a => a.Name, b => b.MapFrom(b => b.User.FirstName + " " + b.User.LastName))
                .ForMember(a => a.Email, b => b.MapFrom(b => b.User.Email));
        }
    }
}