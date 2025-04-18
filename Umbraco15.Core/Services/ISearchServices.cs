using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco15.Core.Services
{
    public interface ISearchServices
    {
        IEnumerable<IPublishedContent> SearchContentNames(string query);
    }
}
