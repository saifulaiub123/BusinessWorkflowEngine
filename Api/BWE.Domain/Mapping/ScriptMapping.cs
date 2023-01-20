using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.Model;

namespace BWE.Domain.Mapping
{
    public class ScriptMapping : Profile
    {
        public ScriptMapping()
        {
            CreateMap<ScriptModel, Script>().ReverseMap();
        }
    }
}
