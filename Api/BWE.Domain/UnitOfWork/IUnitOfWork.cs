using BWE.Domain.DBModel;
using BWE.Domain.IRepository;

namespace BWE.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Repositories
        IRepository<Script, int> ScriptRepository { get; }
        IRepository<ScriptHistory, int> ScriptHistoryRepository { get; }
        IRepository<ScriptUserPermission, int> ScriptUserPermissionRepository { get; }
        #endregion
        void ClearChangeTracker();
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
