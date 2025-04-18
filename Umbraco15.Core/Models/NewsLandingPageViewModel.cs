using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco15.Core.Models
{
    public class NewsLandingPageViewModel: PublishedContentWrapped
    {
        public NewsLandingPageViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }
        public IEnumerable<IPublishedContent> NewsItems { get; set; } = Enumerable.Empty<IPublishedContent>();
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }
    }
    
}
