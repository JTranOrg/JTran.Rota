using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Rota.Service
{
    public interface IService<T>
    {
        Task<string> GetAll();
        Task<string> Get(Guid id);
        Task<string> Get(Expression<Func<T, bool>> query);
    }

    public class Service<T>(IRepository<T> repo) : IService<T>
    {
        public async Task<string> GetAll()
        {
            var result = await repo.GetAll();

            return JsonConvert.SerializeObject(result);
        }

        public virtual async Task<string> Get(Guid id)
        {
            var result = await repo.Get(id);

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> Get(Expression<Func<T, bool>> query)
        {
            var result = await repo.Get(query);

            return JsonConvert.SerializeObject(result.Take(200));
        }
    }
}
