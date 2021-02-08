using CardCost.Core.Entities;
using System.Threading.Tasks;

namespace CardCost.Core.Repositories
{
    public interface IAccessUserRepository
    {
        Task<AccessUser> AddUserAsync(AccessUser user);
        Task<AccessUser> GetUserAsync(string username);
    }
}
