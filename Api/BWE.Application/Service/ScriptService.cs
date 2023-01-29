using AutoMapper;
using BWE.Application.Enum;
using BWE.Application.IService;
using BWE.Domain.Constant;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BWE.Application.Service
{
    [Authorize]
    public class ScriptService : IScriptService
    {
        private readonly IRepository<Script, int> _scriptRepository;
        private readonly IRepository<ScriptUserPermission, int> _scriptUserPermissionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;


        public ScriptService(IRepository<Script, int> scriptRepository, IMapper mapper, IRepository<ScriptUserPermission, int> scriptUserPermissionRepository, UserManager<ApplicationUser> userManager)
        {
            _scriptRepository = scriptRepository;
            _mapper = mapper;
            _scriptUserPermissionRepository = scriptUserPermissionRepository;
            _userManager = userManager;
        }
        public async Task AddScript(ScriptModel model)
        {
            var data = _mapper.Map<Script>(model);
            await _scriptRepository.Insert(data);
            await _scriptRepository.SaveAsync();
        }
        public async Task<List<ScriptViewModel>> GetAll()
        {
            var data = (await _scriptRepository.GetAll(x => !x.IsDeleted, include => include.Server, includes => includes.CreatedByUser))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            var result = _mapper.Map<List<ScriptViewModel>>(data);
            return result;
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
                    await _scriptUserPermissionRepository.Insert(new ScriptUserPermission
                    {
                        ScriptId = (int)newScriptPemission.ScriptId,
                        UserId = newScriptPemission.UserId,
                        PermissionId = newScriptPemission.PermissionId
                    });
                }
            }

            await _scriptRepository.Update(existingScript);
            await _scriptRepository.SaveAsync();

            //await _scriptUserPermissionRepository.DeleteRange(removeScriptUserPermissions);
            //await _scriptUserPermissionRepository.InsertRange(newScriptUserPermissions);
            await _scriptUserPermissionRepository.SaveAsync();

            
        }

        public async Task DeleteScript(int id)
        {
            var scriptPermissions = (await _scriptUserPermissionRepository.GetAll(x => x.ScriptId == id)).ToList();
            await _scriptUserPermissionRepository.DeleteRange(scriptPermissions);
            await _scriptUserPermissionRepository.SaveAsync();

            await _scriptRepository.Delete(id);
            await _scriptRepository.SaveAsync();
        }

        public async Task<bool> HasPermissionToModify(int scriptId, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

            var isAdmin = userRoles.Where(x => x == RoleConst.ADMIN).FirstOrDefault();
            if (isAdmin != null) return true;

            var isScriptOwner = await _scriptRepository.FindBy(x => x.Id == scriptId && x.CreatedBy == userId);
            if (isScriptOwner != null) return true;

            var hasPermissionToModify = await _scriptUserPermissionRepository.FindBy(x => x.ScriptId == scriptId && x.UserId == userId && x.PermissionId == (int)PermissionEnum.Modify);
            if (hasPermissionToModify != null) return true;

            return false;

        }
        public async Task<bool> HasPermissionToView(int scriptId, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

            var isAdmin = userRoles.Where(x => x == RoleConst.ADMIN).FirstOrDefault();
            if (isAdmin != null) return true;

            var isScriptOwner = await _scriptRepository.FindBy(x => x.Id == scriptId && x.CreatedBy == userId);
            if (isScriptOwner != null) return true;

            var hasPermissionToView = await _scriptUserPermissionRepository.FindBy(x => x.ScriptId == scriptId && x.UserId == userId && x.PermissionId == (int)PermissionEnum.Read);
            if (hasPermissionToView != null) return true;

            return false;

        }

        public async Task<bool> IsScriptOwnerOrAdmin(int scriptId, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

            var isAdmin = userRoles.Where(x => x == RoleConst.ADMIN).FirstOrDefault();
            if (isAdmin != null) return true;

            var isScriptOwner = await _scriptRepository.FindBy(x => x.Id == scriptId && x.CreatedBy == userId);
            if (isScriptOwner != null) return true;

            return false;
        }
    }
}
