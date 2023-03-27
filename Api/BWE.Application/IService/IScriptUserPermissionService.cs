using BWE.Domain.Model;

namespace BWE.Application.IService
{
    public interface IScriptUserPermissionService
    {
        Task<List<ScriptUserPermissionModel>> GetScriptUserPermissionsByScriptId(int scriptId);
    }
}
