using MondoCore.Collections;
using MondoCore.Data;

using JTran;
using System.Reflection;
using JTran.Random;

namespace Rota.Transform.Test
{
    [TestClass]
    public class DBPopulators
    {
        private const string ConnectionString = "mongodb://localhost:27017/";
        private const string DatabaseName     = "rota";

        [Ignore]
        [TestMethod]
        [DataRow(1415)]
        public async Task DBPopulators_ships(int numShips)
        {
            await Populate<Ship>("shipgenerator", "ships", new { NumShips = numShips });
        }
        
        [TestMethod]
        [DataRow(1415 * 15)]
        public async Task DBPopulators_persons(int numPersons)
        {
            await Populate<Person>("persongenerator", "persons", new { NumPersons = numPersons });
        }
        
        #region Private

        private async Task Populate<T>(string transform, string  collectionName, object args) where T : IIdentifiable<Guid>, new()
        {
            await using var output = new MongoStreamFactory<T>(DatabaseName, collectionName, ConnectionString);
            var transformer  = await JTranBuilder.CreateTransformer<T>(transform, args);

            transformer.Transform(_dummySource, output);
        }
       
        private const string _dummySource = "{ 'bob': 'bob' }";

        #endregion
    }
}