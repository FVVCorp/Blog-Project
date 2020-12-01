using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Moq;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.RepositoryInterfaces;
using Persistence.UnitTests.Helpers;
using Xunit;

namespace Persistence.UnitTests
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;

        private readonly List<ApplicationUser> _users;

        public UserRepositoryTests()
        {
            _users = GetAllUsers();

            var context = SetupContext(_users);

            _userRepository = new UserRepository(context.Object);
        }

        [Fact]
        public async Task when_getting_all_users_should_return_all_users_from_database()
        {
            var result = await _userRepository.GetAll();

            Assert.Equal(_users.Count, result.Count);

            Enumerable
                .Range(0, _users.Count)
                .ToList()
                .ForEach(i =>
                {
                    Assert.Equal(_users, result);
                });
        }

        [Fact(Skip = "")]
        public async Task when_getting_user_by_id_should_return_this_user_from_database()
        {
            var userId = 3;
            var expectedUser = _users.FirstOrDefault(u => u.Id == userId);
        
            var result = await _userRepository.GetUserByIdAsync(userId);
            
            Assert.Equal(expectedUser, result);
        }

        private Mock<BlogContext> SetupContext(List<ApplicationUser> users)
        {
            var queryableUsers = users.AsQueryable();

            var usersDbSet = DbSetMockHelper.Get(queryableUsers).Object;

            var blogContext = new Mock<BlogContext>();
            blogContext
                .SetupGet(x => x.Users)
                .Returns(usersDbSet);
            

            return blogContext;
        }

        private List<ApplicationUser> GetAllUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser {Id = 1, FirstName = "John", LastName = "Brown"},
                new ApplicationUser {Id = 2, FirstName = "Johan", LastName = "Green"},
                new ApplicationUser {Id = 3, FirstName = "Jam", LastName = "Black"},
                new ApplicationUser {Id = 4, FirstName = "Jackson", LastName = "White"},
                new ApplicationUser {Id = 5, FirstName = "Jack", LastName = "Grey"}
            };
        }
    }
}