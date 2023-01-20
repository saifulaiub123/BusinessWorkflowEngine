using AutoMapper;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.ViewModel;

namespace BWE.Application.Service
{
    public class ServerService : IServerService
    {
        private readonly IRepository<Server, int> _serverRepository;
        private readonly IMapper _mapper;
        public ServerService(IRepository<Server, int> serverRepository, IMapper mapper)
        {
            _serverRepository = serverRepository;
            _mapper = mapper;
        }
        public async Task<List<ServerViewModel>> GetAllServer()
        {
            var result = await _serverRepository.GetAll();
            var data =  _mapper.Map<List<ServerViewModel>>(result);
            return data;
        }
    }
}
