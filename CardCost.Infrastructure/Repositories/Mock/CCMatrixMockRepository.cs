using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Data.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Repositories.Mock
{
    public class CCMatrixMockRepository : ICCMatrixRepository
    {
        public Task AddAsync(Ccmatrix entity)
        {
            CCMatrixMockData.Current.CCMatrix.Add(entity);
            return Task.Run(() => $"CCmatrix record inserted successfully");
        }

        public Task DeleteAsync(Ccmatrix entity)
        {
            CCMatrixMockData.Current.CCMatrix.Remove(entity);
            return Task.Run(() => $"CCmatrix record deleted successfully");
        }

        public async Task<IEnumerable<Ccmatrix>> GetAllAsync() => await Task.Run(() => CCMatrixMockData.Current.CCMatrix);

        public Task<Ccmatrix> GetByCountryCodeAsync(string country) => Task.Run(() => CCMatrixMockData.Current.CCMatrix.FirstOrDefault(x => x.Country == country));

        public Task<Ccmatrix> GetByIdAsync(int id) => Task.Run(() => CCMatrixMockData.Current.CCMatrix.FirstOrDefault(x => x.Id == id));

        public Task UpdateAsync(Ccmatrix entity)
        {
            throw new NotImplementedException();
        }
    }
}
