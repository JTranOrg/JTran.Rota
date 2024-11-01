using MondoCore.Data;
using Newtonsoft.Json;

namespace Rota.Service
{
    public interface IShipRepository
    {
        Task<string> GetAll();
    }

    public class ShipRepository(IReadRepository<Guid, Ship> dataSource) : IShipRepository
    {
        public async Task<string> GetAll()
        {
            var result = await dataSource.Get( (i)=> true ).ToListAsync<Ship>();

            return JsonConvert.SerializeObject(result);
        }
    }
}
