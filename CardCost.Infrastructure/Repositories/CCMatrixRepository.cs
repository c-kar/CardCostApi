using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Repositories
{
    public class CCMatrixRepository : ICCMatrixRepository
    {
        #region Fields

        private readonly ICardCostDbContext _dbContext;

        #endregion

        #region Constructor

        public CCMatrixRepository(ICardCostDbContext dbContext) => _dbContext = dbContext;

        #endregion

        #region Public Methods

        public async Task AddAsync(Ccmatrix entity)
        {
            _dbContext.Set<Ccmatrix>().Add(entity);
         
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Something bad has happened while updating db. {ex}");
            }
        }

        public async Task DeleteAsync(Ccmatrix entity)
        {
            _dbContext.Set<Ccmatrix>().Remove(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Something bad has happened while updating db. {ex}");
            }
        }

        public async Task<IEnumerable<Ccmatrix>> GetAllAsync() => await _dbContext.Ccmatrix.OrderBy(x => x.Id).AsNoTracking().ToListAsync();

        public async Task<Ccmatrix> GetByIdAsync(int id) => await _dbContext.Set<Ccmatrix>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Ccmatrix> GetByCountryCodeAsync(string country) => await _dbContext.Set<Ccmatrix>().AsNoTracking().FirstOrDefaultAsync(x => x.Country == country || x.Country == "OTHERS");

        public async Task UpdateAsync(Ccmatrix entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Something bad has happened while updating db. {ex}");
            }
        }

        #endregion
    }
}
