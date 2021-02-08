using CardCost.Application.Models;
using CardCost.Application.Models.Base;
using System.Threading.Tasks;

namespace CardCost.Application.Interfaces
{
    public interface ICardCostService
    {
        Task<BaseModel> GetCardData(CardCostInput request);
    }
}
