using AutoMapper;
using CardCost.Api.Controllers;
using CardCost.Application.Interfaces;
using CardCost.Application.Services;
using CardCost.Core.Entities;
using CardCost.Core.Models.Base;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Repositories.Mock;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CardCost.Application.Tests
{
    public class CCMatrixTests
    {
        private ICCMatrixRepository _mockRepository;
        private ICCMatrixService _service;
        private ClearingCostMatrixController _clearingCostController;
        private IMapper _mapper;

        public CCMatrixTests()
        {
            var mockMapper = new Mock<IMapper>();
            _mapper = mockMapper.Object;
            _mapper = new MapperConfiguration(c =>
                    c.AddProfile<ApplicationMappings.ApplicationMappings>()).CreateMapper();
            _mockRepository = new CCMatrixMockRepository();
            _service = new CCMatrixService(_mockRepository, _mapper);
            _clearingCostController = new ClearingCostMatrixController(_service);
        }

        [Fact]
        public async Task GetAllCardsCost_ReturnsOkResult()
        {
            // Act
            var response = await _clearingCostController.GetAll();

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<IEnumerable<Ccmatrix>>(result.Value);
        }

        [Fact]
        public async Task GetSingleCardCost_ReturnsOkResult()
        {
            // Arrange
            int id = 1;

            // Act
            var response = await _clearingCostController.GetSingle(id);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<Ccmatrix>(result.Value);
        }

        [Fact]
        public async Task GetSingleCardCost_ReturnsBadRequest()
        {
            // Arrange
            var id = 0;

            // Act
            var response = await _clearingCostController.GetSingle(id);

            // Assert
            var result =Assert.IsType<BadRequestResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task GetSingleCardCost_ReturnsNotFound()
        {
            // Arrange
            var id = 100;

            // Act
            var response = await _clearingCostController.GetSingle(id);

            // Assert
            var result = Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task DeleteCardCost_ReturnsOk()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _clearingCostController.Delete(id);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<string>(result.Value);
        }

        [Fact]
        public async Task DeleteCardCost_ReturnsNotFound()
        {
            // Arrange
            var id = 100;

            // Act
            var response = await _clearingCostController.Delete(id);

            // Assert
            var result = Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task DeleteCardCost_ReturnsBadRequest()
        {
            // Arrange
            var id = 0;

            // Act
            var response = await _clearingCostController.Delete(id);

            // Assert
            var result = Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task CreateCardCost_ReturnsOkResult()
        {
            // Arrange
            var model = new BaseModel
            {
                Country = "ES",
                Cost = 20
            };

            // Act
            var response = await _clearingCostController.CreateClearingCost(model);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<BaseModel>(result.Value);
        }

        [Fact]
        public async Task CreateCardCost_NullRequest_ReturnsBadRequest()
        {
            // Act
            var response = await _clearingCostController.CreateClearingCost(null);

            // Assert
            var result = Assert.IsType<BadRequestResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task UpdateCardCost_ReturnsOkResult()
        {
            // Arrange
            var id = 1;
            var obj = new BaseModel
            {
                Country = "GB",
                Cost = 7
            };
              
            // Act
            var response = await _clearingCostController.UpdateClearingCost(id, obj);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<string>(result.Value);
        }

        [Fact]
        public async Task UpdateCardCost_ReturnsNotFound()
        {
            // Arrange
            var id = 100;
            var obj = new BaseModel
            {
                Country = "GB",
                Cost = 7
            };

            // Act
            var response = await _clearingCostController.UpdateClearingCost(id, obj);

            // Assert
            var result = Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task UpdateCardCost_NullModel_ReturnsBadRequest()
        {
            // Arrange
            var id = 1;
            
            // Act
            var response = await _clearingCostController.UpdateClearingCost(id, null);

            // Assert
            var result = Assert.IsType<BadRequestResult>(response);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
