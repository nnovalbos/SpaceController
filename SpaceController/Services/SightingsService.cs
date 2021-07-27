using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceController.Contracts.Repositories;
using SpaceController.Contracts.Services;
using SpaceController.Models;

namespace SpaceController.Services
{
    public class SightingsService: ISightingsService
    {
        private readonly IGenericRepository genericRepository;

        public SightingsService(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IList<Sighting>> GetAllSightingsAsync(string uri)
        {
            var response = await genericRepository.GetAsync<SightingsResponse>(uri);
            return response.Sightings;
        }
    }
}
