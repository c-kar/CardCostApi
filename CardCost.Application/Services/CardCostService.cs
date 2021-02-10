using AutoMapper;
using CardCost.Application.Interfaces;
using CardCost.Core.Models;
using CardCost.Core.Models.Base;
using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace CardCost.Application.Services
{
    public class CardCostService : ICardCostService
    {
        #region Fields

        private readonly ICardCostRepository _CardCostRepository;
        private readonly ICCMatrixRepository _clearingCostRepository;
        private readonly IBinListClient _CardCostClient;
        private readonly IMapper _mapper;
        private const int CardNumberLength = 16;

        #endregion

        #region Constructor

        public CardCostService(
            ICardCostRepository CardCostRepository, 
            ICCMatrixRepository clearingCostRepository, 
            IBinListClient CardCostClient,
            IMapper mapper)
        {
            _CardCostRepository = CardCostRepository;
            _clearingCostRepository = clearingCostRepository;
            _CardCostClient = CardCostClient;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<BaseModel> GetCardData(CardCostInput request)
        {
            string iin;
            var response = new BaseModel();
            var isValid = this.IsValidCardNumber(request);

            if (isValid)
            {
                // keep first-6 digits
                iin = this.ClearPanNumber(request.Card_Number);

                // Firstly check if there is the bin in Db and retrieve country
                var card = await _CardCostRepository.GetIINAsync(iin);

                if(card is null)
                {
                    try
                    {
                        // Retrieve CountryCode from CardCost api
                        var countryCode = await _CardCostClient.GetDataAsync(iin);

                        // Retrieve cost from Db based on country code
                        var cost = await _clearingCostRepository.GetByCountryCodeAsync(countryCode);
                        
                        // create Bins entity to store it
                        var entity = this.ConvertToEntity(iin, countryCode);

                        // Store "search" to Db
                        await _CardCostRepository.AddIINAsync(entity);

                        response.Country = countryCode;
                        response.Cost = (decimal)cost.Cost;

                        return response;
                    }
                    catch(Exception ex)
                    {
                        throw new Exception($"An error has occured. {ex}");
                    }
                }
                else
                {
                    // Retrieve cost from Db
                    var cost = await _clearingCostRepository.GetByCountryCodeAsync(card.Country);
                    response.Country = card.Country;
                    response.Cost = (decimal)cost.Cost;
                    return response;
                }
            }
            return null;
        }

        #endregion

        #region Private Methods

        private string ClearPanNumber(string pan)
        {
            if (!string.IsNullOrWhiteSpace(pan))
                return pan.Substring(0, 6);
            return string.Empty;
        }

        private Iinlist ConvertToEntity(string iin, string countryCode)
        {
            var ccModel = new CardCostModel
            {
                IIN = iin,
                Country = countryCode
            };

            var entity = _mapper.Map<Iinlist>(ccModel);

            return entity;
        }

        private bool IsValidCardNumber(CardCostInput request)
        {
            return request != null &&
                request.Card_Number != null &&
                !string.IsNullOrWhiteSpace(request.Card_Number) &&
                !string.IsNullOrEmpty(request.Card_Number) &&
                request.Card_Number.Length == CardNumberLength &&
                request.Card_Number.All(char.IsDigit);
        }

        #endregion
    }
}
