using AutoMapper;
using BWE.Application.IService;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(IRepository<Permission, int> permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<List<PermissionViewModel>> GetAllPermission()
        {
            var result = await _permissionRepository.GetAll();
            var data = _mapper.Map<List<PermissionViewModel>>(result);
            return data;
        }
    }
}
