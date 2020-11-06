using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository
    {
        private readonly BlogContext _context;
        public UserRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task<List<ApplicationUser>> GetUsers()
        {
            return await _context.Set<ApplicationUser>().ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async void Create(ApplicationUser applicationUser)
        {
            await _context.Users.AddAsync(applicationUser);
        }

        public async void Update(ApplicationUser applicationUser)
        {
            _context.Users.Update(applicationUser);
        }

        public async void Delete(int userId)
        {
            _context.Remove(await _context.Users
                .SingleOrDefaultAsync(user => Int32.Parse(user.Id) == userId));
        }
    }
}