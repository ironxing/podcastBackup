using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;

namespace TryAsyncRead
{
    public class NewsFeedService
    {

        private readonly string _FeedUri;
        public NewsFeedService(string feedUri)
        {
            _FeedUri = feedUri;
        }

        public async Task GetNewsFeed()
        {
            var rssNewsItems = new List();
            using (var xmlReader = XmlReader.Create(_FeedUri, new XmlReaderSettings() { Async = true }))
            {
                var feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == Microsoft.SyndicationFeed.SyndicationElementType.Item)
                    {
                        ISyndicationItem item = await feedReader.ReadItem();
                        rssNewsItems.Add(item.ConvertToNewsItem());
                    }
                }
            }
            return rssNewsItems.OrderByDescending(p => p.PublishDate).ToArray();
        }
    }
}
