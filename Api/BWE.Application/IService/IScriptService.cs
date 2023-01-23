using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Application.IService
{
    public interface IScriptService
    {
        Task AddScript(ScriptModel model);
        Task<List<ScriptViewModel>> GetScriptsByUserId(int userId);
        Task<ScriptViewModel> GetScriptById(int id);
        Task<List<ScriptViewModel>> GetSharedScriptsByUserId(int userId);
        Task UpdateScript(ScriptModel script);
    }
}
