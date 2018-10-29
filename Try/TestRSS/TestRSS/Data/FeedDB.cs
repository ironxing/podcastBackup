using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Windows.Forms;

namespace TestRSS
{
    class FeedDB
    {
        private static string Url = "http://fooblog.com/feed";
        
        public void test()
        {
            XmlReader reader = XmlReader.Create(Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;
                MessageBox.Show(subject + summary);
            }
        }
        
}
}
