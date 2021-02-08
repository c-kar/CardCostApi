using CardCost.Application.Models;
using CardCost.Core.Entities;
using System.Threading.Tasks;

namespace CardCost.Application.Interfaces
{
    public interface IAccessUserService
    {
        Task<AccessUser> GetUser(AccessUserInput request);
        Task<AccessUser> CreateUser(AccessUserInput request);
    }
}
