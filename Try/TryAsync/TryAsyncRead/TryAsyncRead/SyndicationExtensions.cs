using Microsoft.SyndicationFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryAsyncRead
{
    public static class SyndicationExtensions
    {
        public static NewsItem ConvertToNewsItem(this ISyndicationItem item)
        {
            return new NewsItem(title: item.Title,
                excerpt: item.Description,
                publishDate: item.Published.UtcDateTime,
                uri: item.Links.First().Uri.AbsoluteUri);
        }
    }
}
