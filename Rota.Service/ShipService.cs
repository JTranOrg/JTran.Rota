
using JTran;
using System.Runtime.CompilerServices;

using MondoCore.Common;

namespace Rota.Service
{
    public interface IShipService : IService<Ship>
    {
        Task<string> GetWithOfficers(Guid id);
    }

    public class ShipService(IRepository<Ship> repo, IRepository<Person> personsRepo, ITransformer<Ship> transformer) : Service<Ship>(repo), IShipService
    {
        public override Task<string> Get(Guid id)
        {
            return Get(id, 1000);
        }

        public Task<string> GetWithOfficers(Guid id)
        {
            return Get(id, 4);
        }

        #region Private

        private async Task<string> Get(Guid id, int lowestGrade)
        {
            var ship         = await repo.Get(id);
            var personIds    = ship.Crew.Where( (c)=> c.PositionWeight <= lowestGrade).Select(x => Guid.Parse(x.CrewId));
            var persons      = await personsRepo.Get(personIds);
            var data         = new CombinedData { Ship = ship, Persons = persons }; 
            using var stream = new MemoryStream();

            transformer.Transform(data, stream, new TransformerContext { Arguments = new Dictionary<string, object> { {"lowestGrade", lowestGrade} }});

            return await stream.ReadStringAsync();
        }

        private class CombinedData
        {
            public IList<Person>? Persons { get; set; }
            public Ship?          Ship    { get; set; }
        }

        #endregion
    }
}
