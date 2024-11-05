using System.Net;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using MondoCore.Data;
using Rota.Service;

namespace Rota.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController() : ControllerBase
    {
        protected async Task<ContentResult> HandleResult( Func<Task<string>> fnGetData)
        { 
            try
            { 
                var result = await fnGetData();
                
                return new ContentResult
                {
                    Content     = result,
                    ContentType = "application/json",
                    StatusCode  = 200
                };
            }
            catch (NotFoundException ex) 
            {
                return new ContentResult
                {
                    Content     = ex.Message,
                    ContentType = "text/plain",
                    StatusCode  = 404
                };
            }
            catch (Exception ex2) 
            {
                return new ContentResult
                {
                    Content     = ex2.Message,
                    ContentType = "text/plain",
                    StatusCode  = 500
                };
            }
        }
    }
}
