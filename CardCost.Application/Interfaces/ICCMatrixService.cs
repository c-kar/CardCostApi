using CardCost.Core.Models.Base;
using CardCost.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardCost.Application.Interfaces
{
    public interface ICCMatrixService
    {
        Task<IEnumerable<Ccmatrix>> GetAllClearingCosts();
        Task<Ccmatrix> GetClearingCost(int id);
        Task<BaseModel> CreateClearingCost(BaseModel request);
        Task UpdateClearingCost(int id, BaseModel request);
        Task DeleteClearingCost(int id);
    }
}
