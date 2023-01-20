using BWE.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Application.IService
{
    public interface IServerService
    {
        Task<List<ServerViewModel>> GetAllServer();
    }
}
