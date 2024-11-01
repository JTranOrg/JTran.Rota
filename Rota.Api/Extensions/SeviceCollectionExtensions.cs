using Microsoft.Extensions.DependencyInjection;

using MondoCore.Data;
using Rota.Service;

using MondoCore.MongoDB;

namespace Rota.Api
{
    public static class SeviceCollectionExtensions
    {
        private const string ConnectionString = "mongodb://localhost:27017/";
        private const string DatabaseName     = "rota";

        public static IServiceCollection SetupRota(this IServiceCollection collection) 
        { 
            collection.AddSingleton<IDatabase>( (p)=> new MondoCore.MongoDB.MongoDB(DatabaseName, ConnectionString) )
                      .AddRepositoryReader<Ship>("ships")
                      .AddRepository<Person>("persons")
                      .AddSingleton<IShipRepository, ShipRepository>()
                      .AddSingleton<IShipService, ShipService>()
                      .AddSingleton<IPersonService, PersonService>();

            return collection; 
        }

        private static IServiceCollection AddRepository<T>(this IServiceCollection collection, string repoName) where T : IIdentifiable<Guid>
        {
            return collection.AddRepositoryReader<T>(repoName)
                             .AddSingleton<IRepository<T>, Repository<T>>();
        }

        private static IServiceCollection AddRepositoryReader<T>(this IServiceCollection collection, string name) where T : IIdentifiable<Guid>
        {
            return collection.AddSingleton<IReadRepository<Guid, T>>( (p)=> 
                              {
                                  var db = p.GetRequiredService<IDatabase>();
                              
                                  return db.GetRepositoryReader<Guid, T>(name);
                              });
        }
    }
}
