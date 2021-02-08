using System.Threading.Tasks;

namespace CardCost.Infrastructure.Interfaces
{
    public interface IBinListClient
    {
        Task<string> GetDataAsync(string pan);
    }
}
