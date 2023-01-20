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
    public class ScriptService : IScriptService
    {
        private readonly IRepository<Script, int> _scriptService;
        private readonly IMapper _mapper;

        public ScriptService(IRepository<Script, int> scriptService, IMapper mapper)
        {
            _scriptService = scriptService;
            _mapper = mapper;
        }

        public async Task AddScript(ScriptModel model)
        {
            var data = _mapper.Map<Script>(model);
            await _scriptService.Insert(data);
        }
    }
}
