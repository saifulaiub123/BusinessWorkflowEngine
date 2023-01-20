using BWE.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.IService
{
    public interface IScriptService
    {
        Task AddScript(ScriptModel model);
    }
}
