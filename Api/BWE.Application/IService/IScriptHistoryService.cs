using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Application.IService
{
    public interface IScriptHistoryService
    {
        Task<ScriptHistoryModel> AddReturn(ScriptHistoryModel scriptHistory);
        Task Update(ScriptHistoryModel scriptHistory);
        Task<ScriptHistoryViewModel> GetById(int id);
        Task<List<ScriptHistoryViewModel>> GetByUserId(int userId);
        Task<List<ScriptHistoryViewModel>> GetAll();
    }
}
