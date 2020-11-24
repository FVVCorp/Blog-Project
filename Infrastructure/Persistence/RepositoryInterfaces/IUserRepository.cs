using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> GetUserByIdAsync(int userId);
        Task<ApplicationUser> CreateAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
        Task<ApplicationUser> DeleteAsync(int userId);
    }
}