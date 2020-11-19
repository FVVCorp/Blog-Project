using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Moq;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.RepositoryInterfaces;
using Xunit;

namespace Persistence.UnitTests
{
    public class UserRepositoryTests
    {
        private readonly ApplicationUser _user = new ApplicationUser
        {
            Id = 10, FirstName = "James", LastName = "Orange"
        };
        
        private readonly int _id = 3;
        
        private readonly List<ApplicationUser> _list = new List<ApplicationUser>
        {
            new ApplicationUser {Id = 1, FirstName = "John", LastName = "Brown"},
            new ApplicationUser {Id = 2, FirstName = "Johan", LastName = "Green"},
            new ApplicationUser {Id = 3, FirstName = "Jam", LastName = "Black"},
            new ApplicationUser {Id = 4, FirstName = "Jackson", LastName = "White"},
            new ApplicationUser {Id = 5, FirstName = "Jack", LastName = "Grey"},
            new ApplicationUser {Id = 10, FirstName = "James", LastName = "Orange"}
        };

        private readonly Mock<BlogContext> _mockContext;
        private  IUserRepository _userRepository;

        public UserRepositoryTests()
        {
            _mockContext = new Mock<BlogContext>();
        }
        
        [Fact(Skip = "Unable to test asynchronous method 'GetAllAsync'")]         
        public async Task GetUsersAsync_ReturnsListOfUsers_IfListExists()
        {
            // Arrange
            _mockContext.SetupGet(context => context.Users)
                .Returns(DbSetMock.GetQueryableMockDbSet(_list));
            
            _userRepository = new UserRepository(_mockContext.Object);

            // Act 
            var users = await _userRepository.GetUsersAsync();
            
            // Assert
            Assert.Equal(_list, users);
        }

        [Fact(Skip = "")]
        public async Task GetUserByIdAsync_ReturnsUser_IfUserExists()
        {
            // Arrange
            Random rnd = new Random();
            var value = rnd.Next(0, 5);
            _mockContext.SetupGet(context => context.Users)
                .Returns(DbSetMock.GetQueryableMockDbSet(_list));
            // _userRepository = new UserRepository(_mockContext.Object);

            // Act
            var user = await _userRepository.GetUserByIdAsync(value);
        
            // Assert
            Assert.Equal(_list[value], user);
        }
        
        
        [Fact(Skip = "")]
        public async Task CreateUserAsync_ReturnsCreatedUser_IsUserIsCreated()
        {
            // Arrange
            _mockContext.Setup(context => context.Users).Returns(DbSetMock.GetQueryableMockDbSet(_list));
            _userRepository = new UserRepository(_mockContext.Object);

            // Act
            var user = await _userRepository.CreateAsync(_user);
        
            // Assert
            Assert.Equal(_user, user);
        }
        
        [Fact(Skip = "")]
        public async Task UpdateUserAsync_ReturnsUpdatedUser_IfUserIsUpdated()
        {
            // Arrange
            _mockContext.Setup(context => context.Users).Returns(DbSetMock.GetQueryableMockDbSet(_list));
            _userRepository = new UserRepository(_mockContext.Object);

            // Act
            var user = await _userRepository.UpdateAsync(_user);
        
            // Assert
            Assert.Equal(user, _user);
        }
        
        [Fact(Skip = "")]
        public async Task DeleteUserAsync_ReturnsBooleanResult_IfUserIsExist()
        {
            // Arrange 
            _mockContext.Setup(context => context.Users).Returns(DbSetMock.GetQueryableMockDbSet(_list));
            _userRepository = new UserRepository(_mockContext.Object);
            
            // Act
            var user = await _userRepository.DeleteAsync(_id);
        
            // Assert
            Assert.Equal(user, _user);
        }
    }
}