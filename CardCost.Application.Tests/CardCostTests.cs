using AutoMapper;
using CardCost.Api.Controllers;
using CardCost.Application.Interfaces;
using CardCost.Application.Models;
using CardCost.Application.Services;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Interfaces;
using CardCost.Infrastructure.Repositories.Mock;
using CardCost.Infrastructure.Services;
using System.Net.Http;
using Xunit;

namespace CardCost.Application.Tests
{
    public class CardCostTests
    {
        private ICCMatrixRepository _ccMatrixrepository;
        private ICardCostRepository _repository;
        private ICardCostService _service;
        private CardCostController _cardCostController;
        private IMapper _mapper;
        private IBinListClient _client;
        private IHttpClientFactory _httpClientFactory;

        public CardCostTests()
        {
            _client = new BinListClient(_httpClientFactory);
            _ccMatrixrepository = new CCMatrixMockRepository();
            _repository = new CardCostMockRepository();
            _service = new CardCostService(_repository, _ccMatrixrepository, _client, _mapper);
            _cardCostController = new CardCostController(_service);
        }

        [Fact]
        public void Get_ReturnsOkResult()
        {
            // Act
            var okResult = _cardCostController.GetCardDetails(new CardCostInput { Card_Number = "4305893245679805" });

            // Assert
            Assert.NotNull(okResult);
        }
    }
}
