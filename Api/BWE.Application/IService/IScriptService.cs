using BWE.Domain.DBModel;
using BWE.Domain.Model;

namespace BWE.Application.IService
{
    public interface IScriptService
    {
        Task AddScript(ScriptModel model);
        Task<List<Script>> GetScriptsByUserId(int userId);
    }
}
