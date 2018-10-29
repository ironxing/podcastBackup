using Podcast.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceModel.Syndication;
using Podcast.Data;


namespace Podcast
{
    public partial class Form1 : Form
    {
       
        KategoriList kategoriList = new KategoriList();
        FeedList feedList = new FeedList();
        Feed selectedFeed = new Feed();

        public Form1()

        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kategoriList.List = kategoriList.fillKategori();
            uppdateraKategori();
            uppdateracbKategori();

            feedList.List = feedList.fillFeed();
            uppdateraFeedList();

            kategoriList.KateoriChanged += new KategoriList.KategoriChangeHandler(HandleKategoriChange);
            feedList.FeedChanged += new FeedList.FeedChangeHandler(HandleFeedChange);

            lvFeed.FullRowSelect = true;



            /*  XmlReader reader = XmlReader.Create("http://mandag.libsyn.com/rss");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;

            } */

        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            var KategoriNamn = tbKategori.Text;
            Kategori kategori = new Kategori(KategoriNamn);

            if (String.IsNullOrEmpty(KategoriNamn))
            {
                Console.WriteLine("wow");
            }
            else
            {
                kategoriList.Add(kategori);
                tbKategori.Clear();   
            }
        }

        private void selectKategoriItem(object sender, EventArgs e)
        {
            var kategoriNamn = lbKategori.SelectedItem.ToString();
            tbKategori.Text = kategoriNamn;
        }

        private void selectFeedItem(object sender, EventArgs e)
        {
            var feedTitle = lvFeed.SelectedItems[0].SubItems[1].Text;
            selectedFeed = feedList.List.FirstOrDefault(i => i.Titel == feedTitle);
            
            if (selectedFeed != null)
            {
                selectedFeed.List = AvsnittDB.GetAvsnitt(selectedFeed.Titel);
                uppdateralbAvsnitt(selectedFeed);
            }
        }

        private void selectAvsnitt(object sender, EventArgs e)
        {
            var avsnittTitel = lbAvsnitt.SelectedItem.ToString();
            var avsnitt = selectedFeed.List.FirstOrDefault(i => i.Titel == avsnittTitel);

            if (avsnitt != null)
            {
                lvBeskrivning.Items.Add(avsnitt.Description);
                lvBeskrivning.Items.Add(avsnitt.URI);
                lvBeskrivning.Items.Add(avsnitt.Length);
            }
        }

        private void btnAndraKategori_Click(object sender, EventArgs e)
        {
            var kategoriNamnOld = lbKategori.SelectedItem.ToString();
            var kategoriNamnNew = tbKategori.Text;

            if (String.IsNullOrEmpty(kategoriNamnNew))
            {
                Console.WriteLine("wow");
            }
            else
            {
                kategoriList.changeKategoriNamn(kategoriNamnOld, kategoriNamnNew);
                tbKategori.Clear();
            }
        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            var KategoriNamn = lbKategori.SelectedItem.ToString();
            kategoriList.deleteByNamn(KategoriNamn);
            tbKategori.Clear();
        }

        private void uppdateraKategori()
        {
            lbKategori.Items.Clear();
            foreach( var item in kategoriList.SortedList)
            {
                lbKategori.Items.Add(item.Namn);
            }
        }

        public void uppdateracbKategori()
        {
            cbKategori.Items.Clear();
            foreach (var item in kategoriList.SortedList)
            {
                cbKategori.Items.Add(item.Namn);
            }
        }

        private void uppdateraFeedList()
        {
            lvFeed.Items.Clear();
            
            foreach (var item in feedList.SortedList)
            {
                var AntalAvsnitt = item.AntalAvsnitt.ToString();
                var Titel = item.Titel.ToString();
                var Frekvens = item.Frekvens.ToString();
                var Kategori = item.Kategori.ToString();

                ListViewItem listitem = new ListViewItem(new[] { AntalAvsnitt, Titel, Frekvens, Kategori });
                lvFeed.Items.Add(listitem);
            }
        }

        private void uppdateralbAvsnitt(Feed feed)
        {
            lbAvsnitt.Items.Clear();

            foreach (var item in feed.SortedList)
            {
                lbAvsnitt.Items.Add(item.Titel.ToString());
            }
        }

        private void btnNyFeed_Click(object sender, EventArgs e)
        {
            var Url = tbUrl.Text;
            var Frekvens = int.Parse(cbFrekvens.SelectedItem.ToString()); 
            string Kategori = cbKategori.SelectedItem.ToString();
            Feed feed = new Feed(Frekvens, Url, Kategori);
            
            feed.GetFeedInfo();
            feed.List = feed.GetAvsnitts();
            feed.saveAvsnitt();

            feedList.Add(feed);
            tbUrl.Clear();
        }

        public void HandleKategoriChange()
        {
            kategoriList.saveKategori();
            uppdateraKategori();
            uppdateracbKategori();
        }

        public void HandleFeedChange()
        {
            feedList.saveFeed();
            uppdateraFeedList();
        }

        
    }
}
