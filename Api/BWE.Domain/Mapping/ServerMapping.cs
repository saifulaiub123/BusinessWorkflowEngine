using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.ViewModel;

namespace BWE.Domain.Mapping
{
    public class ServerMapping : Profile
    {
        public ServerMapping()
        {
            CreateMap<ServerViewModel, Server>()
                .ReverseMap();
        }
    }
}
