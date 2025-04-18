using Examine;
using Examine.Search;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace Umbraco15.Core.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly IExamineManager _examineManager;
        private readonly UmbracoHelper _umbracoHelper;

        public SearchServices(IExamineManager examineManager, UmbracoHelper umbracoHelper)
        {
            _examineManager = examineManager;
            _umbracoHelper = umbracoHelper;
        }
        public IEnumerable<IPublishedContent> SearchContentNames(string query)
        {
            IEnumerable<string> ids = Array.Empty<string>();
            if (!string.IsNullOrEmpty(query) && _examineManager.TryGetIndex("ExternalIndex", out IIndex? index))
            {
                ids = index
                    .Searcher
                    .CreateQuery("content")
                    .NodeTypeAlias("newsArticle")
                    .And()
                    .Field("pageTitle", query)
                    .OrderByDescending(new SortableField[] { new SortableField("publishDate") })
                    .Execute()
                    .Select(x => x.Id);
            }
            foreach (var id in ids)
            {
                yield return _umbracoHelper.Content(id);
            }
        }

    }
}
