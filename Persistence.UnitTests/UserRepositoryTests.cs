using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Moq;
using Persistence.Repository_Interfaces;
using Xunit;

namespace Persistence.UnitTests
{
    public class UserRepositoryTests
    {
        private readonly Mock<IUserRepository> _repositoryMock = new Mock<IUserRepository>();

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
        
            
        [Fact]
        public async Task GetUsersAsync_ReturnsListOfUsers_IfListExists()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetUsersAsync()).ReturnsAsync(_list);
            IUserRepository userRepository = _repositoryMock.Object;
            
            // Act
            var users = await userRepository.GetUsersAsync();
            
            // Assert 
            Assert.Equal(_list, users);
            Assert.Equal(_list.Count, users.Count);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_IfUserExists()
        {
            // Arrange
            Random rnd = new Random();
            var value = rnd.Next(0, 5);
            _repositoryMock.Setup(repo => repo.GetUserByIdAsync(value))
                .ReturnsAsync(_list[value]);
            IUserRepository userRepository = _repositoryMock.Object;
            
            // Act
            var user = await userRepository.GetUserByIdAsync(value);

            // Assert
            Assert.Equal(_list[value], user);
        }

        [Fact]
        public async Task CreateUserAsync_ReturnsCreatedUser_IsUserIsCreated()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.CreateAsync(_user))
                .ReturnsAsync(_user);
            IUserRepository userRepository = _repositoryMock.Object;
            // Act
            var user = await userRepository.CreateAsync(_user);

            // Assert
            Assert.Equal(_user, user);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnsUpdatedUser_IfUserIsUpdated()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.UpdateAsync(_user))
                .ReturnsAsync(_user);
            IUserRepository repository = _repositoryMock.Object;

            // Act
            var user = await repository.UpdateAsync(_user);

            // Assert
            Assert.Equal(user, _user);
        }

        [Fact]
        public async Task DeleteUserAsync_ReturnsBooleanResult_IfUserIsExist()
        {
            // Arrange 
            _repositoryMock.Setup(repo => repo.DeleteAsync(_id))
                .ReturnsAsync(_user);
            IUserRepository repository = _repositoryMock.Object;
            // Act
            var user = await repository.DeleteAsync(_id);

            // Assert
            Assert.Equal(user, _user);
        }
    }
}