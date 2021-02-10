using AutoFixture;
using AutoMapper;
using CardCost.Api.Controllers;
using CardCost.Application.Interfaces;
using CardCost.Application.Services;
using CardCost.Core.Models;
using CardCost.Core.Models.Base;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Interfaces;
using CardCost.Infrastructure.Repositories.Mock;
using CardCost.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CardCost.Application.Tests
{
    public class CardCostTests
    {
        private CardCostController _cardCostController;
        private ICardCostService _service;
        private ICCMatrixRepository _ccMatrixRepository;
        private ICardCostRepository _cardCostRepository;
        private IBinListClient _client;
        private IMapper _mapper;

        public CardCostTests()
        {
            var mockMapper = new Mock<IMapper>();
            _mapper = mockMapper.Object;
            _mapper = new MapperConfiguration(c =>
                    c.AddProfile<ApplicationMappings.ApplicationMappings>()).CreateMapper();

            // Arrange --- Mock IHttpClientFactory
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'country': 'GR'}"),
                });
            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = fixture.Create<Uri>();
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            _client = new MockBinListClient(httpClientFactory.Object);
            _ccMatrixRepository = new CCMatrixMockRepository();
            _cardCostRepository = new CardCostMockRepository();
            _service = new CardCostService(_cardCostRepository, _ccMatrixRepository, _client, _mapper);
            _cardCostController = new CardCostController(_service);
        }

        [Fact]
        public async Task PostCardCost_ReturnsOkResult()
        {
            // Arrange
            var model = new CardCostInput
            {
                Card_Number = "4305895160019805"
            };

            // Act
            var response = await _cardCostController.GetCardDetails(model);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<BaseModel>(result.Value);
        }

        [Fact]
        public async Task PostCardCost_MockClient_ReturnsOkResult()
        {
            // Arrange
            var model = new CardCostInput
            {
                Card_Number = "4309895160019805"
            };

            // Act
            var response = await _cardCostController.GetCardDetails(model);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsAssignableFrom<BaseModel>(result.Value);
        }

        [Fact]
        public async Task PostCardCost_NullInput_ReturnsBadRequest()
        {
            // Act
            var response = await _cardCostController.GetCardDetails(null);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task PostCardCost_EmptyCardNumber_ReturnsBadRequest()
        {
            // Arrange
            var model = new CardCostInput();

            // Act
            var response = await _cardCostController.GetCardDetails(model);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task PostCardCost_WrongLength_ReturnsBadRequest()
        {
            // Arrange
            var model = new CardCostInput
            {
                Card_Number = "43098951600"
            };

            // Act
            var response = await _cardCostController.GetCardDetails(model);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task PostCardCost_NoDigits_ReturnsBadRequest()
        {
            // Arrange
            var model = new CardCostInput
            {
                Card_Number = "test card number"
            };

            // Act
            var response = await _cardCostController.GetCardDetails(model);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
