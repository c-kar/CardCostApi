using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using CardCost.Infrastructure.Data.MockData;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Repositories.Mock
{
    public class AccessUserMockRepository : IAccessUserRepository
    {
        public async Task<AccessUser> AddUserAsync(AccessUser user)
        {
            await Task.Run(() => AccessUserMockData.Current.AccessUser.Add(user));
            return user;
        }

        public async Task<AccessUser> GetUserAsync(string username) => await Task.Run(() => AccessUserMockData.Current.AccessUser.FirstOrDefault(x => x.Username == username));
    }
}
