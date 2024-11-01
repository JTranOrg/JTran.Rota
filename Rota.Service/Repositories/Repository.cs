using MondoCore.Data;

namespace Rota.Service
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<T> Get(Guid id);
    }

    public class Repository<T>(IReadRepository<Guid, T> dataSource) : IRepository<T> where T : IIdentifiable<Guid>
    {
        public Task<IList<T>> GetAll()
        {
            return dataSource.Get( (i)=> true ).ToListAsync<T>();
        }

        public Task<T> Get(Guid id)
        {
            return dataSource.Get(id);
        }
    }
}
