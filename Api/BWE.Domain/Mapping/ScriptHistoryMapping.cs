using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Domain.Mapping
{
    public class ScriptHistoryMapping : Profile
    {
        public ScriptHistoryMapping()
        {
            CreateMap<ScriptHistory, ScriptHistoryModel>().ReverseMap();
            CreateMap<ScriptHistory, ScriptHistoryViewModel>()
                .ForMember(a => a.ScriptId, b => b.MapFrom(b => b.Script.Id))
                .ForMember(a => a.ScriptName, b => b.MapFrom(b => b.Script.Name))
                .ForMember(a => a.CreatedByName, b => b.MapFrom(b => b.CreatedByUser.UserName))
                .ForMember(a => a.ScriptOwnerName, b => b.MapFrom(b => b.Script.CreatedByUser.UserName))
                .ReverseMap();
        }
    }
}