using AutoMapper;
using BWE.Application.Helper;
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
            model.Password = PasswordHelper.EncodePassword(model.Password);
            var data = _mapper.Map<Server>(model);
            await _serverRepository.Insert(data);
            await _serverRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var existingData = await _serverRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if (existingData != null)
            {
                existingData.IsDeleted = true;

                await _serverRepository.Update(existingData);
                await _serverRepository.SaveAsync();
            }
        }

        public async Task<List<ServerViewModel>> GetAllServer()
        {
            var result = await _serverRepository.GetAll(x=> !x.IsDeleted);
            var data =  _mapper.Map<List<ServerViewModel>>(result);
            var customData = data.Select(x => new ServerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IpAddress = x.IpAddress,
                MachineName = x.MachineName,
                UserName = x.UserName
            }).ToList();
            return customData;
        }

        public async Task<ServerViewModel> GetById(int id)
        {
            var data = await _serverRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            var result = _mapper.Map<ServerViewModel>(data);
            result.Password = PasswordHelper.DecodePassword(result.Password);
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
                existingData.Password = PasswordHelper.EncodePassword(server.Password);

                await _serverRepository.Update(existingData);
                await _serverRepository.SaveAsync();
            }
        }
    }
}
