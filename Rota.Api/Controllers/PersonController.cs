using System.Net;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using Rota.Service;

namespace Rota.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController(IPersonService svc) : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ContentResult> GetAll()
        {
            var result = await svc.GetAll();

            return new ContentResult
            {
                Content     = result,
                ContentType = "application/json",
                StatusCode  = 200,
            };
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ContentResult> Get(string id)
        {
            var result = await svc.Get(Guid.Parse(id));

            return new ContentResult
            {
                Content     = result,
                ContentType = "application/json",
                StatusCode  = 200,
            };
        }
    }
}
