using MondoCore.Data;

using Newtonsoft.Json;

using Rota.Service;

namespace Rota.Transform.Test
{
    [TestClass]
    public class DBPopulators
    {
        private const string ConnectionString = "mongodb://localhost:27017/";
        private const string DatabaseName     = "rota";

       // [Ignore]
        [TestMethod]
        [DataRow(1415)]
        public async Task DBPopulators_ships(int numShips)
        {
            var db      = new MondoCore.MongoDB.MongoDB(DatabaseName, ConnectionString);            
            var reader  = db.GetRepositoryReader<Guid, Person>("persons");
            var persons = await reader.Get( (i)=> true ).ToListAsync();
            var json    = JsonConvert.SerializeObject(persons);

            await Populate<Ship>("shipgenerator", "ships", new { NumShips = numShips }, "persons", json);
        }
        
        [Ignore]
        [TestMethod]
        [DataRow(1415 * 15)]
        public async Task DBPopulators_persons(int numPersons)
        {
            await Populate<Person>("persongenerator", "persons", new { NumPersons = numPersons });
        }
        
        #region Private

        private async Task Populate<T>(string transform, string  collectionName, object args, string? docName = null, string? docContents = null) where T : IIdentifiable<Guid>, new()
        {
            await using var output = new MongoStreamFactory<T>(DatabaseName, collectionName, ConnectionString);
            var transformer  = await JTranBuilder.CreateTransformer<T>(transform, args, docName, docContents);

            var result = transformer.Transform(_dummySource);

            transformer.Transform(_dummySource, output);
        }
       
        private const string _dummySource = "{ 'bob': 'bob' }";

        #endregion
    }
}