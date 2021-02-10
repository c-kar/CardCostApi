using AutoMapper;
using CardCost.Api.Controllers;
using CardCost.Application.Interfaces;
using CardCost.Application.Services;
using CardCost.Application.ApplicationMappings;
using CardCost.Core.Models;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Repositories.Mock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CardCost.Core.Entities;

namespace CardCost.Application.Tests
{
    public class AccessUserTests
    {
        private IAccessUserRepository _mockRepository;
        private AccessUserController _accessUserController;
        private IAccessUserService _service;

        public AccessUserTests()
        {
            var mockMapper = new Mock<IMapper>();
            IMapper _mapper = mockMapper.Object;
            _mapper = new MapperConfiguration(c =>
                    c.AddProfile<ApplicationMappings.ApplicationMappings>()).CreateMapper();
            _mockRepository = new AccessUserMockRepository();
            _service = new AccessUserService(_mockRepository, _mapper);
            _accessUserController = new AccessUserController(_service);
        }

        [Fact]
        public async Task CreateUser_ReturnsOkResult()
        {
            // Arrange
            var requestModel = new AccessUserInput 
            { 
               Username = "testuser",
               Password = "testpass!"
            };

            // Act
            var response = await _accessUserController.RegisterUser(requestModel);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<string>(result.Value);
        }

        [Fact]
        public async Task CreateUser_ReturnsBadRequest()
        {
            // Act
            var response = await _accessUserController.RegisterUser(null);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task CreateUser_EmptyInputs_ReturnsBadRequest()
        {
            // Arrange
            var requestModel = new AccessUserInput
            {
                Username = "",
                Password = ""
            };

            // Act
            var response = await _accessUserController.RegisterUser(requestModel);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task AuthenticateUser_ReturnsOkResult()
        {
            // Arrange
            var requestModel = new AccessUserInput
            {
                Username = "user1",
                Password = "ckarou"
            };

            // Act
            var response = await _accessUserController.Authenticate(requestModel);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<AccessUser>(result.Value);
        }

        [Fact]
        public async Task AuthenticateUser_WrongCredentials_ReturnsBadRequest()
        {
            // Arrange
            var requestModel = new AccessUserInput
            {
                Username = "user100",
                Password = "test"
            };

            // Act
            var response = await _accessUserController.Authenticate(requestModel);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task AuthenticateUser_NullInput_ReturnsBadRequest()
        {
            // Act
            var response = await _accessUserController.Authenticate(null);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
