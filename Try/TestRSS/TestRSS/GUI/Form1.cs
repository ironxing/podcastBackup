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

namespace TestRSS
{
    public partial class Form1 : Form
    {
        public List<String> Kategorier;

        public Form1()
        {
            InitializeComponent();
            List<String> Kategorier = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Url = "http://wakingup.libsyn.com/rss";

            using (XmlReader reader = XmlReader.Create(Url))
                {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                int count = feed.Items.Count();
            };
              





            /*
                            foreach (SyndicationItem item in feed.Items)
                            {
                                String subject = item.Title.Text;
                                MessageBox.Show(subject);
                                var link = item.Links[1];

                                    MessageBox.Show("Link Title: " + link.Title + "URI: " + link.Uri + "RelationshipType: " + link.RelationshipType
                                      + "MediaType: " + link.MediaType + "Length: " + link.Length);

                        }*/

        }

        private void Ny_Click(object sender, EventArgs e)
        {
            string kategori = tbKategori.Text;
            Kategorier.Add(kategori);
            Uppdatera();

        }
        
        private void Uppdatera()
        {
            lvKategori.Items.Clear();
            foreach (var item in Kategorier)
            {
                lvKategori.Items.Add(item);
            }
            tbKategori.Clear();
        }
    }
}
