using CardCost.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardCost.Core.Repositories
{
    public interface ICCMatrixRepository
    {
        Task<IEnumerable<Ccmatrix>> GetAllAsync();
        Task<Ccmatrix> GetByIdAsync(int id);
        Task<Ccmatrix> GetByCountryCodeAsync(string country);
        Task AddAsync(Ccmatrix entity);
        Task UpdateAsync(Ccmatrix entity);
        Task DeleteAsync(Ccmatrix entity);
    }
}
