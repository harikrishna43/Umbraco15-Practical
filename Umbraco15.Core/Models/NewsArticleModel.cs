using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco15.Core.Models
{
    public class NewsArticleModel
    {
        public string Key { get; set; }
        public string PageTitle { get; set; }
        public string FeatureImage { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Url { get; set; }
    }
}
