using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Repository_Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(int userId);
        void Create(ApplicationUser user);
        void Update(ApplicationUser user);
        void Delete(int userId);
    }
}