using Podcast.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void deleteByTitel(string str)
        {
            int index = List.FindIndex(i => i.Titel == str);
            List.RemoveAt(index);
            if (FeedChanged != null)
            {
                FeedChanged();
            }
        }

        public void changeFeed(string titel, string newkat, int newFrek)
        {
            var feed = List.FirstOrDefault(i => i.Titel == titel);
            feed.Frekvens = newFrek;
            feed.Kategori = newkat;
            if (FeedChanged != null)
            {
                FeedChanged();
            }
        }

        public bool UrlExistInList(string url)
        {
            var feed = List.FirstOrDefault(i => i.Url == url);
            if(feed != null)
            {
                MessageBox.Show("RSS URL finns redan i listan. Du kan ändra det genom att klicka det i listan, göra ändringar och klicka på knappen Ändra");
                return true;
            } else
            {
                return false;
            }

        }
    }
}

