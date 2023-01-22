using AutoMapper;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.Service
{
    [Authorize]
    public class ScriptService : IScriptService
    {
        private readonly IRepository<Script, int> _scriptRepository;
        private readonly IMapper _mapper;

        public ScriptService(IRepository<Script, int> scriptRepository, IMapper mapper)
        {
            _scriptRepository = scriptRepository;
            _mapper = mapper;
        }
        public async Task AddScript(ScriptModel model)
        {
            var data = _mapper.Map<Script>(model);
            await _scriptRepository.Insert(data);
            await _scriptRepository.SaveAsync();
        }

        public async Task<List<ScriptViewModel>> GetScriptsByUserId(int userId)
        {
            var data = (await _scriptRepository.GetAll(x => x.CreatedBy == userId && !x.IsDeleted, include => include.Server, includes => includes.CreatedByUser))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            var result = _mapper.Map<List<ScriptViewModel>>(data);
            return result;
        }
    }
}
