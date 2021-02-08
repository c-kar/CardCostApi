using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Repositories
{
    public class AccessUserRepository : IAccessUserRepository
    {
        #region 

        private readonly ICardCostDbContext _dbContext;

        #endregion

        #region Constructor

        public AccessUserRepository(ICardCostDbContext dbContext) => _dbContext = dbContext;

        #endregion

        #region Public Methods

        public async Task<AccessUser> AddUserAsync(AccessUser user)
        {
            _dbContext.Set<AccessUser>().Add(user);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
           
            return user;
        }

        public async Task<AccessUser> GetUserAsync(string username) => await _dbContext.AccessUser.AsNoTracking().FirstOrDefaultAsync(x => x.Username == username);

        #endregion

    }
}
