using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco15.Core.Models
{
    public class NewsModel
    {
        public IEnumerable<NewsArticleModel> NewsItems { get; set; } = Enumerable.Empty<NewsArticleModel>();
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }
    }
}
