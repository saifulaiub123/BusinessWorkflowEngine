using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Script, int> ScriptRepository { get; }
        IRepository<ScriptHistory, int> ScriptHistoryRepository { get; }
        IRepository<ScriptUserPermission, int> ScriptUserPermissionRepository { get; }
        void ClearChangeTracker();
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
