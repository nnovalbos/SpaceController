using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceController.Models;

namespace SpaceController.Contracts.Services
{
    public interface ISightingsService
    {
        Task<IList<Sighting>> GetAllSightingsAsync(string uri);
    }
}
