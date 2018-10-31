using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryAsyncRead
{
    public class NewsItem
    {
        public NewsItem(string title, string excerpt, DateTime publishDate, string uri)
        {
            Title = title;
            Excerpt = excerpt;
            PublishDate = publishDate;
            Uri = uri;
        }

        public string Title { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
        public string Uri { get; set; }
    }
}
