using AutoMapper;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
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

        public async Task Add(ServerModel model)
        {
            var data = _mapper.Map<Server>(model);
            await _serverRepository.Insert(data);
            await _serverRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _serverRepository.Delete(id);
            await _serverRepository.SaveAsync();
        }

        public async Task<List<ServerViewModel>> GetAllServer()
        {
            var result = await _serverRepository.GetAll();
            var data =  _mapper.Map<List<ServerViewModel>>(result);
            return data;
        }

        public async Task<ServerViewModel> GetById(int id)
        {
            var data = await _serverRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            var result = _mapper.Map<ServerViewModel>(data);
            return result;
        }

        public async Task Update(ServerModel server)
        {
            var existingData = await _serverRepository.FindBy(x => x.Id == server.Id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.Name = server.Name;
                existingData.IpAddress = server.IpAddress;
                existingData.MachineName = server.MachineName;
                existingData.UserName = server.UserName;
                existingData.Password = server.Password;

                await _serverRepository.Update(existingData);
                await _serverRepository.SaveAsync();
            }
        }
    }
}
