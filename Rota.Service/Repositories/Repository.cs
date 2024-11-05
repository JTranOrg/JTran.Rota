using MondoCore.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Rota.Service
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<T> Get(Guid id);
        Task<IList<T>> Get(IEnumerable<Guid> ids);
        Task<IList<T>> Get(Expression<Func<T, bool>> query);
    }

    public class Repository<T>(IReadRepository<Guid, T> dataSource) : IRepository<T> where T : IIdentifiable<Guid>
    {
        public async Task<IList<T>> GetAll()
        {
            var result = await dataSource.Get( (i)=> true ).ToListAsync<T>();

            return result.Take(200).ToList();
        }

        public Task<T> Get(Guid id)
        {
            return dataSource.Get(id);
        }

        public Task<IList<T>> Get(IEnumerable<Guid> ids)
        {
            return dataSource.Get(ids).ToListAsync<T>();
        }

        public Task<IList<T>> Get(Expression<Func<T, bool>> query)
        {
            return dataSource.Get(query).ToListAsync<T>();
        }
    }
}
