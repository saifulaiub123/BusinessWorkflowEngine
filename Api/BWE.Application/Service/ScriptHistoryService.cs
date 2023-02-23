using AutoMapper;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
using BWE.Domain.UnitOfWork;
using BWE.Domain.ViewModel;

namespace BWE.Application.Service
{
    public class ScriptHistoryService : IScriptHistoryService
    {
        private readonly IRepository<ScriptHistory, int> _scriptHistoryRepository;
        private readonly IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public ScriptHistoryService(IRepository<ScriptHistory, int> scriptHistoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _scriptHistoryRepository = scriptHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ScriptHistoryModel> AddReturn(ScriptHistoryModel scriptHistory)
        {
            var data = _mapper.Map<ScriptHistory>(scriptHistory);
            var result = await _unitOfWork.ScriptHistoryRepository.InsertReturn(data);
            var scriptHistoryModel = _mapper.Map<ScriptHistoryModel>(result);
            return scriptHistoryModel;
        }

        public async Task<List<ScriptHistoryViewModel>> GetAll()
        {
            var data = await _unitOfWork.ScriptHistoryRepository.GetAll(x => !x.IsDeleted, y => y.Script, y => y.CreatedByUser, y => y.Script.CreatedByUser);
            var result = _mapper.Map<List<ScriptHistoryViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<ScriptHistoryViewModel> GetById(int id)
        {
            var data = await _unitOfWork.ScriptHistoryRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<ScriptHistoryViewModel>(data);
            return result;
        }

        public async Task<List<ScriptHistoryViewModel>> GetByUserId(int userId)
        {
            var data = await _unitOfWork.ScriptHistoryRepository.GetAll(x => !x.IsDeleted && x.CreatedBy == userId, y=> y.Script, y=> y.CreatedByUser, y=> y.Script.CreatedByUser);
            var result = _mapper.Map<List<ScriptHistoryViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task Update(ScriptHistoryModel scriptHistory)
        {
            _unitOfWork.ClearChangeTracker();
            var existingScriptHistory = await _unitOfWork.ScriptHistoryRepository.GetById(scriptHistory.Id);
            if(existingScriptHistory != null)
            {
                existingScriptHistory.Status = scriptHistory.Status;
                existingScriptHistory.Output = scriptHistory.Output;
                await _unitOfWork.ScriptHistoryRepository.Update(existingScriptHistory);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
