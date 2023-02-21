using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Domain.UnitOfWork;
using BWE.Infrastructure.DBContext;
using BWE.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IRepository<Script, int> _scriptRepository;
        public IRepository<ScriptHistory, int> _scriptHistoryRepository;
        public IRepository<ScriptUserPermission, int> _scriptUserPermissionRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Script, int> ScriptRepository
        {
            get { return _scriptRepository = _scriptRepository ?? new Repository<Script, int>(_dbContext); }
        }
        public IRepository<ScriptHistory, int> ScriptHistoryRepository
        {
            get { return _scriptHistoryRepository = _scriptHistoryRepository ?? new Repository<ScriptHistory, int>(_dbContext); }
        }

        public IRepository<ScriptUserPermission, int> ScriptUserPermissionRepository
        {
            get { return _scriptUserPermissionRepository = _scriptUserPermissionRepository ?? new Repository<ScriptUserPermission, int>(_dbContext); }
        }

        public void ClearChangeTracker()
        {
            _dbContext.ChangeTracker.Clear();
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
