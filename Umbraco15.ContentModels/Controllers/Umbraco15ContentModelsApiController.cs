using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Umbraco15.ContentModels.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Umbraco15.ContentModels")]
    public class Umbraco15ContentModelsApiController : Umbraco15ContentModelsApiControllerBase
    {

        [HttpGet("ping")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public string Ping() => "Pong";
    }
}
