using CardCost.Core.Entities;
using System.Threading.Tasks;

namespace CardCost.Core.Repositories
{
    public interface ICardCostRepository
    {
        Task<Iinlist> GetIINAsync(string iin);
        Task<string> AddIINAsync(Iinlist entity);
    }
}
