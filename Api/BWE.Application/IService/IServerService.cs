using BWE.Domain.Model;
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
        Task Add(ServerModel model);
        Task<ServerViewModel> GetById(int id);
        Task Update(ServerModel script);
        Task Delete(int id);
    }
}
