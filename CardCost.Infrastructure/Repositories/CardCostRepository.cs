using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Repositories
{
    public class CardCostRepository : ICardCostRepository
    {
        #region 

        private readonly ICardCostDbContext _dbContext;

        #endregion

        #region Constructor

        public CardCostRepository(ICardCostDbContext dbContext) => _dbContext = dbContext;

        #endregion

        #region Public Methods

        public async Task<string> AddIINAsync(Iinlist entity)
        {
            _dbContext.Set<Iinlist>().Add(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return $"Something bad has happened while updating db. {ex}";
            }

            return $"Bin record inserted successfully.";
        }

        public async Task<Iinlist> GetIINAsync(string iin)
        {
            try
            {
                var result = await _dbContext.Iinlist.AsNoTracking().FirstOrDefaultAsync(x => x.Iin == iin);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception($"An error has occured. {ex}");
            }
        }

        #endregion
    }
}