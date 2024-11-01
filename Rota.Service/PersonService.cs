using Newtonsoft.Json;

namespace Rota.Service
{
    public interface IPersonService
    {
        Task<string> GetAll();
        Task<string> Get(Guid id);
    }

    public class PersonService(IRepository<Person> repo) : IPersonService
    {
        public async Task<string> GetAll()
        {
            var result = await repo.GetAll();

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> Get(Guid id)
        {
            var result = await repo.Get(id);

            return JsonConvert.SerializeObject(result);
        }
    }
}
