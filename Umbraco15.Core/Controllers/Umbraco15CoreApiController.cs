using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Umbraco15.Core.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Umbraco15.Core")]
    public class Umbraco15CoreApiController : Umbraco15CoreApiControllerBase
    {

        [HttpGet("ping")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public string Ping() => "Pong";
    }
}
