namespace Rota.Service
{
    public interface IShipService
    {
        Task<string> GetAll();
    }

    public class ShipService(IShipRepository repo) : IShipService
    {
        public async Task<string> GetAll()
        {
            return await repo.GetAll();
        }
    }
}
