﻿using Microsoft.EntityFrameworkCore;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;
using BWE.Infrastructure.DBContext;

namespace BWE.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserRole(UserRole userRole)
        {
           _context.UserRoles.Remove(userRole);
           await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserById(int id)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).Include(x=> x.Status).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<ApplicationUser>> GetPendingUsers()
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).Where(x => x.StatusId == 1).ToListAsync();
        }

        public async Task UpdateUserRole(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();
        }
 
        public async Task<List<Status>> GetAllStatus()
        {
            return await _context.Status.ToListAsync();
        }
        public async Task<Status> GetStatusById(int id)
        {
            return await _context.Status.Where(x=> x.Id == id).FirstOrDefaultAsync();
        }
    }
}
