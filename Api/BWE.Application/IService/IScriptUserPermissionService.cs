using BWE.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.IService
{
    public interface IScriptUserPermissionService
    {
        Task<List<ScriptUserPermissionModel>> GetScriptUserPermissionsByScriptId(int scriptId);
    }
}
