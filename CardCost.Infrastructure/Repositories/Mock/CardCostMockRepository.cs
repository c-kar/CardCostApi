using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Data.MockData;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Repositories.Mock
{
    public class CardCostMockRepository : ICardCostRepository
    {
        public async Task<string> AddIINAsync(Iinlist entity)
        {
            IINListMockData.Current.Iinlist.Add(entity);
            return await Task.Run(() => $"Bin List inserted successfully");
        }

        public Task<Iinlist> GetIINAsync(string iin) => Task.Run(() => IINListMockData.Current.Iinlist.FirstOrDefault(x => x.Iin == iin));
    }
}
