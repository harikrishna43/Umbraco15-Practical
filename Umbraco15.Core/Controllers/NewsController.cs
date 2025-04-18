using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco15.PublishedModels;
using Umbraco.Extensions;
using Umbraco15.Core.Models;
using Umbraco15.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Core.Models;

namespace Umbraco15.Core.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : Controller
    {
        IPublishedValueFallback _publishedValueFallback;
        private readonly ISearchServices _searchService;

        private readonly IUmbracoContextFactory _contextFactory;

        public NewsController(IUmbracoContextFactory contextFactory,ISearchServices searchService,ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback)
        {
            _publishedValueFallback = publishedValueFallback;
            _searchService= searchService;
            _contextFactory = contextFactory;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll(string search="", int page=1)
        {
            using var context = _contextFactory.EnsureUmbracoContext();
            var root = context.UmbracoContext.Content.GetAtRoot().FirstOrDefault();
            
            var result = !String.IsNullOrEmpty(search)?_searchService.SearchContentNames(search): root.Children<IPublishedContent>();
            
            result = result.OrderByDescending(x => x.Value<DateTime>("publishDate"));
            var totalItems = result.Count();
            var pageSize =2; 
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var pagedList = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var model = new NewsModel()
            {
                NewsItems = pagedList.Select(x=>
                new NewsArticleModel { 
               Description = x.Value<IHtmlEncodedString>("content").ToString().Substring(0,100),
                    FeatureImage = x.Value<MediaWithCrops>("featuredImage").Url(mode:UrlMode.Absolute),
                    Url = x.Url(mode: UrlMode.Absolute),
                    Key = x.Key.ToString(),
                    PageTitle = x.Value<string>("pageTitle"),
                    PublishedDate = x.Value<DateTime>("publishDate")
                }),
                TotalItems=totalItems,
                TotalPages=totalPages,
                Page=page
            };
            return Ok(model);
        }
    }
}
