using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using Rota.Service;

namespace Rota.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController(IShipService svc) : BaseController
    {
        [HttpGet]
        [Route("list")]
        public Task<ContentResult> GetAll([FromQuery] string? search = null)
        {
            search = search?.ToLower();

            return string.IsNullOrWhiteSpace(search) 
                ? HandleResult( async ()=> await svc.Get( (i)=> true ) )
                : HandleResult( async ()=> await svc.Get( (i)=> i.Name.ToLower().Contains(search) ) );
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ContentResult> Get(string id)
        {
            return HandleResult( async ()=> await svc.Get(Guid.Parse(id)) );
        }

        [HttpGet]
        [Route("{id}/officers")]
        public Task<ContentResult> GetWithOfficers(string id)
        {
            return HandleResult( async ()=> await svc.GetWithOfficers(Guid.Parse(id)) );
        }
    }
}
