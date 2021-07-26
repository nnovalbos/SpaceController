using System.Threading.Tasks;

namespace SpaceController.Contracts.Repositories
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri);
    }
}
