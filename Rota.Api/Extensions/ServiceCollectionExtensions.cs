using Microsoft.Extensions.DependencyInjection;

using MondoCore.Data;
using Rota.Service;

using MondoCore.MongoDB;
using System.Reflection;
using MondoCore.Common;
using JTran;

namespace Rota.Api
{
    public static class ServiceCollectionExtensions
    {
        private const string ConnectionString = "mongodb://localhost:27017/";
        private const string DatabaseName     = "rota";

        public static IServiceCollection SetupRota(this IServiceCollection collection) 
        { 
            collection.AddSingleton<IDatabase>( (p)=> new MondoCore.MongoDB.MongoDB(DatabaseName, ConnectionString) )
                      .AddService<Person>("persons")
                      .AddRepository<Ship>("ships")
                      .AddTransformer<Ship>("ship")
                      .AddSingleton<IShipService, ShipService>();

            return collection; 
        }

        private static IServiceCollection AddService<T>(this IServiceCollection collection, string repoName) where T : IIdentifiable<Guid>
        {
            return collection.AddRepository<T>(repoName)
                             .AddSingleton<IService<T>, Service<T>>();
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

        private static IServiceCollection AddTransformer<T>(this IServiceCollection collection, string name) where T : IIdentifiable<Guid>
        {
            var transform = LoadFile($"{name}.jtran");

            return collection.AddSingleton<ITransformer<T>>( (p)=> 
                              {
                                  return TransformerBuilder.FromString(transform)
                                                           .Build<T>();
                              });
        }

        private static string LoadFile(string name)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Rota.Api.Transforms.{name}");
                       
            if(stream == null)
                throw new FileNotFoundException(name);

            return stream!.ReadString();
        }



    }
}
