using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.IService
{
    public interface IPermissionService
    {
        Task<List<PermissionViewModel>> GetAllPermission();
    }
}
