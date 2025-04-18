using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco15.Core.Models
{
    public class NewsArticleViewModel : PublishedContentWrapped
    {
        public NewsArticleViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }
    }
}