using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umbraco.Cms.Core.Media.EmbedProviders;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Umbraco15.Core.Controllers
{
    public class RssFeedController : Controller
    {
        private readonly IUmbracoContextFactory _contextFactory;

        public RssFeedController(IUmbracoContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        [Route("rss")]
        public IActionResult NewsFeed()
        {
            using var context = _contextFactory.EnsureUmbracoContext();
            var root = context.UmbracoContext.Content.GetAtRoot().FirstOrDefault();
            var newsItems = root?.DescendantsOfType("newsArticle")
                                .OrderByDescending(x => x.Value<DateTime>("publishDate"));

            var rss = new XDocument(
                new XElement("rss", new XAttribute("version", "2.0"),
                    new XElement("channel",
                        new XElement("title", "Your Website News Feed"),
                        new XElement("link", $"{Request.Scheme}://{Request.Host}/"),
                        new XElement("description", "Latest News from Our Site"),
                        newsItems?.Select(item => new XElement("item",
                            new XElement("title", item.Name),
                        new XElement("link", item.Url(mode: UrlMode.Absolute)),
                            new XElement("description", item.Value<IHtmlEncodedString>("content").ToString().Substring(0, 100) ?? string.Empty),
                            new XElement("pubDate", item.Value<DateTime>("publishDate").ToUniversalTime().ToString("R"))
                        ))
                    )
                )
            );

            return Content(rss.ToString(), "application/rss+xml", Encoding.UTF8);
        }
    }
}
