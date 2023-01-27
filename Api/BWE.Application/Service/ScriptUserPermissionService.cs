using AutoMapper;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.Service
{
    public class ScriptUserPermissionService : IScriptUserPermissionService
    {
        private readonly IRepository<ScriptUserPermission, int> _scriptUserPermissionRepository;
        private readonly IMapper _mapper;
        public ScriptUserPermissionService(IMapper mapper, IRepository<ScriptUserPermission, int> scriptUserPermissionRepository)
        {
            _mapper = mapper;
            _scriptUserPermissionRepository = scriptUserPermissionRepository;
        }

        public async Task<List<ScriptUserPermissionModel>> GetScriptUserPermissionsByScriptId(int scriptId)
        {
            var result = await _scriptUserPermissionRepository.GetAll(x => x.ScriptId == scriptId);
            var data = _mapper.Map<List<ScriptUserPermissionModel>>(result);
            return data;
        }
    }
}
