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
        public async Task<List<SharedScriptUserViewModel>> GetScriptSharedUser(int scriptId)
        {
            var sharedScript = (await _scriptUserPermissionRepository.GetAll(x => x.ScriptId == scriptId && !x.Script.IsDeleted, 
                include => include.User,
                include => include.Permission
                ))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            var result = _mapper.Map<List<SharedScriptUserViewModel>>(sharedScript);
            return result;
        }
        
        public async Task UpdateScript(ScriptModel script)
        {
            var newScriptUserPermissions = new List<ScriptUserPermission>();
            var removeScriptUserPermissions = new List<ScriptUserPermission>();

            var existingScript = await _scriptRepository.FindBy(x => x.Id == (int)script.Id, include => include.ScriptUserPermissions);
            if(existingScript != null)
            {
                existingScript.Name = script.Name;
                existingScript.Description = script.Description;
                existingScript.DestinationServerId = script.DestinationServerId;
                existingScript.Content = script.Content;
            }

            foreach (var scriptPermission in existingScript.ScriptUserPermissions)
            {
                var isExist = script.ScriptUserPermissions.Where(x => x.ScriptId == scriptPermission.ScriptId && x.UserId == scriptPermission.UserId).FirstOrDefault();
                if (isExist is null)
                {
                    removeScriptUserPermissions.Add(scriptPermission);
                }
                else
                {
                    scriptPermission.PermissionId = isExist.PermissionId;
                }
            }

            foreach (var newScriptPemission in script.ScriptUserPermissions)
            {
                var isExist = existingScript.ScriptUserPermissions.Where(x => x.ScriptId == newScriptPemission.ScriptId && x.UserId == newScriptPemission.UserId).FirstOrDefault();
                if (isExist is null)
                {
                    newScriptUserPermissions.Add(new ScriptUserPermission
                    {
                        ScriptId = newScriptPemission.ScriptId,
                        UserId = newScriptPemission.UserId,
                        PermissionId = newScriptPemission.PermissionId
                    });
                }
            }

            await _scriptRepository.Update(existingScript);
            await _scriptUserPermissionRepository.DeleteRange(removeScriptUserPermissions);
            await _scriptUserPermissionRepository.InsertRange(newScriptUserPermissions);

            await _scriptRepository.SaveAsync();
        }

        public async Task DeleteScript(int id)
        {
            var scriptPermissions = (await _scriptUserPermissionRepository.GetAll(x => x.ScriptId == id)).ToList();
            await _scriptUserPermissionRepository.DeleteRange(scriptPermissions);
            await _scriptUserPermissionRepository.SaveAsync();

            await _scriptRepository.Delete(id);
            await _scriptRepository.SaveAsync();
        }
    }
}
