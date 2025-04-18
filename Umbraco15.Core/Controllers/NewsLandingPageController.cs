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
using Umbraco.Extensions;
using Umbraco15.Core.Models;
using Umbraco15.Core.Services;

namespace Umbraco15.Core.Controllers
{
    public class NewsLandingPageController : RenderController
    {
        IPublishedValueFallback _publishedValueFallback;
        private readonly ISearchServices _searchService;
        public NewsLandingPageController(ISearchServices searchService,ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _publishedValueFallback = publishedValueFallback;
            _searchService= searchService;
        }
        [HttpGet]
        public IActionResult Index([FromQuery(Name = "search")] string search, [FromQuery(Name = "year")] int year, [FromQuery(Name = "page")] int page=1)
        {
            var result= !String.IsNullOrEmpty(search)?_searchService.SearchContentNames(search):CurrentPage.Children<IPublishedContent>();
            //var pages = CurrentPage?.Children();
            if (year > 0 && String.IsNullOrEmpty(search)) { 
                result= result.Where(x => x.Value<DateTime>("publishDate").Year == year);
            }
            result = result.OrderByDescending(x => x.Value<DateTime>("publishDate"));
            var totalItems = result.Count();
            var pageSize =2; // Define the number of items per page
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var model = new NewsLandingPageViewModel(CurrentPage, _publishedValueFallback)
            {
                NewsItems = result.Skip((page - 1) * pageSize).Take(pageSize),
                TotalItems=totalItems,
                TotalPages=totalPages,
                Page=page
            };
            return CurrentTemplate(model);
        }
    }
}
