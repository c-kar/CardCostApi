using CardCost.Infrastructure.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Services
{
    public class MockBinListClient : IBinListClient
    {
        #region Fields

        private IHttpClientFactory _httpClientFactory;

        #endregion

        #region Constructor

        public MockBinListClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Public Methods

        public async Task<string> GetDataAsync(string pan)
        {
            var validCountry = "GR";
            return await Task.Run(() => validCountry);
        }

        #endregion
    }
}
