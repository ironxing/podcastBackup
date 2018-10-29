using Podcast.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Podcast.Data
{
    class FeedDB
    {
        private const string path = @"..\..\XMLFiles\Feeds.xml";

        public static void GetFeedInfo(Feed feed)
        {
            var Url = feed.Url;
            using (XmlReader reader = XmlReader.Create(Url))
            {
                SyndicationFeed rssFeed = SyndicationFeed.Load(reader);
                feed.AntalAvsnitt = rssFeed.Items.Count();
                feed.Titel = rssFeed.Title.Text.ToString();
            };
        }

        public static List<Avsnitt> GetAvsnitts(string Url)
        {
            List<Avsnitt> List = new List<Avsnitt>();
            using (XmlReader reader = XmlReader.Create(Url))
            {
                SyndicationFeed rssFeed = SyndicationFeed.Load(reader);
         
                foreach (SyndicationItem item in rssFeed.Items)
                {
                    Avsnitt avsnitt = new Avsnitt();
                    avsnitt.Titel = item.Title.Text;
                    avsnitt.Description = item.Summary.Text;

                    foreach (var link in item.Links)
                    {
                        avsnitt.URI = link.Uri.ToString();
                        avsnitt.Length = link.Length.ToString();
                    }

                    List.Add(avsnitt);
                }

                return List;
            };
        }

        public static void saveFeeds(List<Feed> feeds)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("   ");

            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Feeds");

            foreach (Feed feed in feeds)
            {
                xmlOut.WriteStartElement("Feed");
                xmlOut.WriteElementString("Titel", feed.Titel);
                xmlOut.WriteElementString("Url", feed.Url);
                xmlOut.WriteElementString ("AntalAvsnitt", Convert.ToString(feed.AntalAvsnitt));
                xmlOut.WriteElementString("Frekvens", Convert.ToString(feed.Frekvens));
                xmlOut.WriteElementString("Kategori", feed.Kategori);
                xmlOut.WriteEndElement();
            }
            xmlOut.WriteEndElement();
            xmlOut.Close();
        }

        public static List<Feed> GetFeeds()
        {
            List<Feed> feeds = new List<Feed>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            XmlReader xmlin = XmlReader.Create(path, settings);

            if (xmlin.ReadToDescendant("Feed"))
            {
                do
                {
                    Feed feed = new Feed();
                    xmlin.ReadStartElement("Feed");
                    feed.Titel = xmlin.ReadElementContentAsString();
                    feed.Url= xmlin.ReadElementContentAsString();
                    feed.AntalAvsnitt = int.Parse(xmlin.ReadElementContentAsString());
                    feed.Frekvens = int.Parse(xmlin.ReadElementContentAsString());
                    feed.Kategori = xmlin.ReadElementContentAsString();

                    feeds.Add(feed);
                }
                while (xmlin.ReadToNextSibling("Feed"));
            }
            xmlin.Close();
            return feeds;
        }
    }
}

