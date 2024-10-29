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
            await Populate("shipgenerator", "ships", new { NumShips = numShips });
        }
        
        #region Private

        private async Task Populate(string transform, string  collectionName, object args)
        {
            await using var output = new MongoStreamFactory<Ship>(DatabaseName, collectionName, ConnectionString);
            var transformer  = await JTranBuilder.CreateTransformer(transform, args);

            transformer.Transform(_dummySource, output);
        }
       
        private const string _dummySource = "{ 'bob': 'bob' }";

        #endregion
    }
}