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
            CreateMap<ScriptHistory, ScriptHistoryViewModel>().ReverseMap();
        }
    }
}