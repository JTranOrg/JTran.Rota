using System.Net;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using Rota.Service;

namespace Rota.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController(IService<Person> svc) : BaseController
    {
        [HttpGet]
        [Route("")]
        public Task<ContentResult> GetAll()
        {
            return HandleResult( async ()=> await svc.GetAll() );
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ContentResult> Get(string id)
        {
            return HandleResult( async ()=> await svc.Get(Guid.Parse(id)) );
        }
    }
}
