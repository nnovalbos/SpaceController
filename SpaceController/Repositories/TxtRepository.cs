using System;
using System.Threading.Tasks;
using SpaceController.Contracts.Repositories;
using SpaceController.Contracts.Utils;

namespace SpaceController.Repositories
{
    public class TxtRepository : IGenericRepository
    {
        public async Task<T> GetAsync<T>(string uri) where T : ITxtParseable
        {
            // simulamos un tiempo de procesamiento 
            await Task.Delay(200);

            if ((T)Activator.CreateInstance(typeof(T)) is ITxtParseable parseable)
            {
                return (T)Convert.ChangeType((T)parseable.Parser(uri), typeof(T));
            }

            return default;
        }  
    }
}