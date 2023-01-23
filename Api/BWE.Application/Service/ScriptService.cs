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
        private readonly IRepository<ScriptUserPermission, int> _scriptUserPermissionRepository;
        private readonly IMapper _mapper;

        public ScriptService(IRepository<Script, int> scriptRepository, IMapper mapper, IRepository<ScriptUserPermission, int> scriptUserPermissionRepository)
        {
            _scriptRepository = scriptRepository;
            _mapper = mapper;
            _scriptUserPermissionRepository = scriptUserPermissionRepository;
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

        public async Task<ScriptViewModel> GetScriptById(int id)
        {
            var data = await _scriptRepository.FindBy(x => x.Id == id && !x.IsDeleted, include => include.Server, includes => includes.CreatedByUser);
            var result = _mapper.Map<ScriptViewModel>(data);
            return result;
        }

        public async Task<List<ScriptViewModel>> GetSharedScriptsByUserId(int userId)
        {
            var sharedScript = (await _scriptUserPermissionRepository.GetAll(x => x.UserId == userId && !x.Script.IsDeleted, 
                include => include.Script, 
                include => include.Script.Server, 
                include => include.Script.CreatedByUser,
                include => include.Permission
                ))
                .OrderByDescending(x => x.DateCreated)
                .Select(x => x.Script)
                .ToList();
            var result = _mapper.Map<List<ScriptViewModel>>(sharedScript);
            return result;
        }
        
        public async Task UpdateScript(ScriptModel script)
        {
            var data = await _scriptRepository.GetById((int)script.Id);
            if(data != null)
            {
                data.Name = script.Name;
                data.Description = script.Description;
                data.DestinationServerId = script.DestinationServerId;
                data.Content = script.Content;
            }
            await _scriptRepository.Update(data);
            await _scriptRepository.SaveAsync();
        }
    }
}
