using AutoMapper;
using BWE.Application.Enum;
using BWE.Application.IService;
using BWE.Domain.Constant;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.Model;
using BWE.Domain.UnitOfWork;
using BWE.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace BWE.Application.Service
{
    public class ScriptService : IScriptService
    {
        private readonly IRepository<Script, int> _scriptRepository;
        private readonly IRepository<ScriptUserPermission, int> _scriptUserPermissionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public ScriptService(IRepository<Script, int> scriptRepository, 
            IMapper mapper, 
            IRepository<ScriptUserPermission, int> scriptUserPermissionRepository, 
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork)
        {
            _scriptRepository = scriptRepository;
            _mapper = mapper;
            _scriptUserPermissionRepository = scriptUserPermissionRepository;
            _userManager = userManager;

            _unitOfWork = unitOfWork;
        }
        public async Task AddScript(ScriptModel model)
        {
            var data = _mapper.Map<Script>(model);
            await _scriptRepository.Insert(data);
            await _scriptRepository.SaveAsync();
        }
        public async Task<List<ScriptViewModel>> GetAll()
        {
            var data = (await _scriptRepository.GetAll(x => !x.IsDeleted && x.CreatedByUser.Status != 0, include => include.Server, includes => includes.CreatedByUser))
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
            var sharedScript = (await _scriptUserPermissionRepository.GetAll(x => x.UserId == userId && !x.Script.IsDeleted && x.Script.CreatedByUser.Status != 0, 
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
            var sharedScript = (await _scriptUserPermissionRepository.GetAll(x => x.ScriptId == scriptId && !x.Script.IsDeleted && x.User.Status != 0, 
                include => include.User,
                include => include.Permission
                ))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            var result = _mapper.Map<List<SharedScriptUserViewModel>>(sharedScript);
            return result;
        }
        
        public async Task UpdateScript(UpdateScriptModel script)
        {
            var newScriptUserPermissions = new List<ScriptUserPermission>();
            var removeScriptUserPermissions = new List<ScriptUserPermission>();

            var existingScript = await _unitOfWork.ScriptRepository.FindBy(x => x.Id == (int)script.Id);
            if(existingScript != null)
            {
                existingScript.Name = script.Name;
                existingScript.Description = script.Description;
                existingScript.DestinationServerId = script.DestinationServerId;
                existingScript.Content = script.Content;
                existingScript.SendTo = script.SendTo;
                await _unitOfWork.ScriptRepository.Update(existingScript);
            }
            foreach(var deletedScript in script.DeletedScriptUserPermissions)
            {
                if(deletedScript.ScriptId != 0)
                {
                    var data = await _scriptUserPermissionRepository.FindBy(x => x.ScriptId == deletedScript.ScriptId && x.UserId == deletedScript.UserId);
                    if (data != null)
                    {
                        await _unitOfWork.ScriptUserPermissionRepository.Delete(data);
                    }
                } 
            }
            foreach (var addOrUpdateScript in script.ScriptUserPermissions)
            {
                var data = await _unitOfWork.ScriptUserPermissionRepository.FindBy(x => x.ScriptId == addOrUpdateScript.ScriptId && x.UserId == addOrUpdateScript.UserId);
                if (data != null)
                {
                    data.PermissionId = addOrUpdateScript.PermissionId;
                    await _unitOfWork.ScriptUserPermissionRepository.Update(data);
                }
                else
                {
                    var mappedResult = _mapper.Map<ScriptUserPermission>(addOrUpdateScript);                  
                    await _unitOfWork.ScriptUserPermissionRepository.Insert(mappedResult);
                }
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteScript(int id)
        {
            var script = await _unitOfWork.ScriptRepository.GetById(id);
            await _unitOfWork.ScriptRepository.Delete(script);

            var scriptUserPermissions = await _unitOfWork.ScriptUserPermissionRepository.GetAll(x => x.ScriptId == id);
            if(scriptUserPermissions.Count > 0)
            {
                await _unitOfWork.ScriptUserPermissionRepository.DeleteRange(scriptUserPermissions);
            }
            await _unitOfWork.CommitAsync();
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
