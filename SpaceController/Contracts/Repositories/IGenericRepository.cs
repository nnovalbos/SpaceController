using System.Threading.Tasks;
using SpaceController.Contracts.Utils;

namespace SpaceController.Contracts.Repositories
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri) where T : ITxtParseable;
    }
}
