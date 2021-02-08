﻿using CardCost.Infrastructure.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Services
{
    public class BinListClient : IBinListClient
    {
        #region Fields

        private IHttpClientFactory _httpClientFactory;

        #endregion

        #region Constructor

        public BinListClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Public Methods

        public async Task<string> GetDataAsync(string pan)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("binlist");
            var response = await httpClient.GetStringAsync(pan);

            dynamic data = JObject.Parse(response);

            var countryCode = (string)data.country.alpha2;

            return countryCode;
        }

        #endregion
    }
}
