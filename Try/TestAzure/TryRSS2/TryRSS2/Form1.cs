using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TryRSS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Url = "http://wakingup.libsyn.com/rss";

            using (XmlReader reader = XmlReader.Create(Url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                int count = feed.Items.Count();
                var itemList = feed.Items.ToList();
                var title = feed.Title.Text.ToString();
                MessageBox.Show(title);

                foreach (SyndicationItem item in feed.Items)
                {
                    string Titel = item.Title.Text.ToString();
                    string summary = item.Summary.Text.ToString();

                    //foreach (SyndicationElementExtension extension in item.ElementExtensions)
                    //{
                    //    XElement ele = extension.GetObject<XElement>();
                    //    MessageBox.Show(ele.Value);
                    //}

                    foreach (var link in item.Links)
                    {
                        MessageBox.Show("URI: " + link.Uri);
                        MessageBox.Show("MediaType: " + link.MediaType);
                        MessageBox.Show("Length: " + link.Length);
                    }

                    MessageBox.Show(Titel + "________" + summary);
                }
            };

           
        }
    }
}
