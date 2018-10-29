using Podcast.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.Logic
{
    class FeedList
    {
        public delegate void FeedChangeHandler();
        public event FeedChangeHandler FeedChanged;

        public List<Feed> List { get; set; }

        public List<Feed> SortedList
        {
            get
            {
                return List.OrderBy(i => i.Titel).ToList();
            }
        }

        public FeedList()
        {
            List = new List<Feed>();
        }

        public void Add(Feed feed)
        {
            List.Add(feed);
            if (FeedChanged != null)
            {
                FeedChanged();
            }
        }

        public void saveFeed()
        {
            FeedDB.saveFeeds(List);
        }

        public List<Feed> fillFeed()
        {
            return FeedDB.GetFeeds();
        }
    }
}

