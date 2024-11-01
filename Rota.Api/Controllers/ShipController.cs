using System.Net;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using Rota.Service;

namespace Rota.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController(IShipService svc) : ControllerBase
    {
        [HttpGet]
        public async Task<ContentResult> Get()
        {
            var result = await svc.GetAll();

            return new ContentResult
            {
                Content     = result,
                ContentType = "application/json",
                StatusCode  = 200,
            };
        }
    }
}
