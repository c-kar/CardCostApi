using CardCost.Core.Models;
using CardCost.Core.Models.Base;
using System.Threading.Tasks;

namespace CardCost.Application.Interfaces
{
    public interface ICardCostService
    {
        Task<BaseModel> GetCardData(CardCostInput request);
    }
}
