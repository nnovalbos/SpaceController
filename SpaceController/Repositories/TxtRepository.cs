using System;
using System.Threading.Tasks;
using SpaceController.Contracts.Repositories;

namespace SpaceController.Repositories
{
    public class TxtRepository : IGenericRepository
    {
        public TxtRepository()
        {
        }

        public Task<T> GetAsync<T>(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
