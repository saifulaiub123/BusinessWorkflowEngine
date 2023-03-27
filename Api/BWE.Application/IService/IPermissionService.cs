using BWE.Domain.ViewModel;

namespace BWE.Application.IService
{
    public interface IPermissionService
    {
        Task<List<PermissionViewModel>> GetAllPermission();
    }
}
