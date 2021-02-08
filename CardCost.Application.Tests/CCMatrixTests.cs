using AutoMapper;
using CardCost.Api.Controllers;
using CardCost.Application.Interfaces;
using CardCost.Application.Models.Base;
using CardCost.Application.Services;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Repositories.Mock;
using Microsoft.AspNetCore.Mvc;
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
            _mockRepository = new CCMatrixMockRepository();
            _service = new CCMatrixService(_mockRepository, _mapper);
            _clearingCostController = new ClearingCostMatrixController(_service);
        }

        [Fact]
        public async Task GetAllCardsCost_ReturnsOkResult()
        {
            // Act
            var result = await _clearingCostController.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetSingleCardCost_ReturnsOkResult()
        {
            int id = 1;

            // Act
            var okResult = await _clearingCostController.GetSingle(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task GetSingleCardCost_ReturnsBadRequest()
        {
            var id = 0;

            // Act
            var result = await _clearingCostController.GetSingle(id);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetSingleCardCost_ReturnsNotFound()
        {
            var id = 100;

            // Act
            var result = await _clearingCostController.GetSingle(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCardCost_ReturnsOk()
        {
            var id = 1;

            // Act
            var result = await _clearingCostController.Delete(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteCardCost_ReturnsBadRequest()
        {
            var id = 100;

            // Act
            var result = await _clearingCostController.Delete(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
