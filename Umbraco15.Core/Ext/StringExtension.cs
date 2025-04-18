using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Umbraco15.Core.Ext
{
    public static class StringExtension
    {
        public static string ReplaceQueryStringItem(this string url, string key, string value)
        {
            return !url.Contains("?") ? string.Format("{0}?{1}={2}", (object)url, (object)key, (object)value) : (url.Contains(key + "=") ? Regex.Replace(url, @"^?" + key + @"=(\d+)", key + "=" + value) : string.Format("{0}&{1}={2}", (object)url, (object)key, (object)value));
        }
        public static Uri GetAbsoluteUri(this HttpRequest request)
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            uriBuilder.Port = (int)request.Host.Port;
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Query = request.QueryString.ToString();
            return uriBuilder.Uri;
        }
    }
}
