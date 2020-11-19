using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.RepositoryInterfaces;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _context;
        public UserRepository(BlogContext context)
        {
            _context = context;
        }
        public virtual async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<ApplicationUser> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<ApplicationUser> CreateAsync(ApplicationUser applicationUser)
        {
            await _context.Users.AddAsync(applicationUser);
            await _context.SaveChangesAsync();
            
            return applicationUser;    
        }
        public async Task<ApplicationUser> UpdateAsync(ApplicationUser applicationUser)
        {
            _context.Users.Update(applicationUser);    
            await _context.SaveChangesAsync();
            
            return applicationUser;
        }
        public async Task<ApplicationUser> DeleteAsync(int userId)
        {
            var entity = await _context.Users
                .FirstOrDefaultAsync(user => user.Id == userId);
            _context.Users.Remove(entity);
            
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}