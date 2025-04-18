using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace Umbraco15.Core.Controllers
{
    [ApiController]
    [BackOfficeRoute("umbraco15core/api/v{version:apiVersion}")]
    [Authorize(Policy = AuthorizationPolicies.SectionAccessContent)]
    [MapToApi(Constants.ApiName)]
    public class Umbraco15CoreApiControllerBase : ControllerBase
    {
    }
}
