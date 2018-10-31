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
using Podcast.Validation;


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
            feedList.List = feedList.fillFeed();

            uppdateraKategori();
            uppdateracbKategori();
            uppdateraFeedList();

            kategoriList.KateoriChanged += new KategoriList.KategoriChangeHandler(HandleKategoriChange);
            feedList.FeedChanged += new FeedList.FeedChangeHandler(HandleFeedChange);

            lvFeed.FullRowSelect = true;
            refreshRssTimer5();
            refreshRssTimer10();
            refreshRssTimer15();
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            var KategoriNamn = tbKategori.Text.Substring(0, 1).ToUpper() + tbKategori.Text.Substring(1).ToLower();
            Kategori kategori = new Kategori(KategoriNamn);
            kategoriList.NamnExistInList(KategoriNamn);
            if (KategoriInputValid()&&!kategoriList.NamnExistInList(KategoriNamn))
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
            lvBeskrivning.Items.Clear();
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

            if (KategoriInputValid()) { 
                kategoriList.changeKategoriNamn(kategoriNamnOld, kategoriNamnNew);
                tbKategori.Clear();
            }

            UpdateFeedKategori(kategoriNamnOld, kategoriNamnNew);
        } 

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            var KategoriNamn = lbKategori.SelectedItem.ToString();
            kategoriList.deleteByNamn(KategoriNamn);
            tbKategori.Clear();

            UpdateFeedKategori(KategoriNamn, "Unknown");
        }

        private void UpdateFeedKategori(string kategoriNamnOld, string kategoriNamnNew)
        {
            var List = feedList.List;
            
            foreach (var feed in List)
            {
                if (feed.Kategori == kategoriNamnOld)
                {
                    feed.ChangeKategori(kategoriNamnNew);
                }
            }

            feedList.saveFeed();
            uppdateraFeedList();
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

            foreach (var item in feed.List)
            {
                lbAvsnitt.Items.Add(item.Titel.ToString());
            }
        }
            
        private async void btnNyFeed_Click(object sender, EventArgs e)
        {
            var Url = tbUrl.Text;
            feedList.UrlExistInList(Url);
            if (FeedInputValid() && !feedList.UrlExistInList(Url))
            {
                var Frekvens = int.Parse(cbFrekvens.SelectedItem.ToString());
                string Kategori = cbKategori.SelectedItem.ToString();
                Feed feed = new Feed(Frekvens, Url, Kategori);

                feed.GetFeedInfo();
                await Task.Run(() => feed.List = feed.GetAvsnitts());

                feed.saveAvsnitt();
                feedList.Add(feed);
                tbUrl.Clear();
            }
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

        public void refreshRssTimer5()
        {
            var timer5 = new Timer();
            timer5.Tick += new EventHandler(refreshTimer_Tick5);
            timer5.Interval = 5 * 1000 * 60;
            timer5.Start();
        }

        private async void refreshTimer_Tick5(object sender, EventArgs e)
        {
            foreach (var feed in feedList.List)
            {
                if (feed.Frekvens == 5) { 
                    await Task.Run(() => feed.List = feed.GetAvsnitts());
                    feed.saveAvsnitt();

                    selectedFeed.List = AvsnittDB.GetAvsnitt(selectedFeed.Titel);
                    uppdateralbAvsnitt(selectedFeed);
                }
            }
        }

        public void refreshRssTimer10()
        {
            var timer10 = new Timer();
            timer10.Tick += new EventHandler(refreshTimer_Tick10);
            timer10.Interval = 10 * 1000 * 60;
            timer10.Start();
        }

        private async void refreshTimer_Tick10(object sender, EventArgs e)
        {
            foreach (var feed in feedList.List)
            {
                if (feed.Frekvens == 10)
                {
                    await Task.Run(() => feed.List = feed.GetAvsnitts());
                    feed.saveAvsnitt();

                    selectedFeed.List = AvsnittDB.GetAvsnitt(selectedFeed.Titel);
                    uppdateralbAvsnitt(selectedFeed);
                }
            }
        }

        public void refreshRssTimer15()
        {
            var timer15 = new Timer();
            timer15.Tick += new EventHandler(refreshTimer_Tick15);
            timer15.Interval = 15*1000*60;
            timer15.Start();
        }

        private async void refreshTimer_Tick15(object sender, EventArgs e)
        {
            foreach (var feed in feedList.List)
            {
                if (feed.Frekvens == 15)
                {
                    await Task.Run(() => feed.List = feed.GetAvsnitts());
                    feed.saveAvsnitt();

                    selectedFeed.List = AvsnittDB.GetAvsnitt(selectedFeed.Titel);
                    uppdateralbAvsnitt(selectedFeed);
                }
            }
        }

        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
            foreach (var feed in feedList.List)
            {
                await Task.Run(() => feed.List = feed.GetAvsnitts());
                feed.saveAvsnitt();

                selectedFeed.List = AvsnittDB.GetAvsnitt(selectedFeed.Titel);
                uppdateralbAvsnitt(selectedFeed);
            }
        }

        private void btnTaBortFeed_Click(object sender, EventArgs e)
        {
            var feedTitle = lvFeed.FocusedItem.SubItems[1].Text;
            feedList.deleteByTitel(feedTitle);
            AvsnittDB.DeleteAvsnittXML(feedTitle);
        }

        private void btnSparaFeed_Click(object sender, EventArgs e)
        {
            if (Validater.DropDownBoxIsSelected(cbFrekvens)
                   && Validater.DropDownBoxIsSelected(cbKategori)) { 
                var feedTitle = lvFeed.FocusedItem.SubItems[1].Text;
                var nyFrekvens = int.Parse(cbFrekvens.SelectedItem.ToString());
                string nyKategori = cbKategori.SelectedItem.ToString();
                feedList.changeFeed(feedTitle, nyKategori, nyFrekvens);
            }
        }

        private bool KategoriInputValid()
        {
            return Validater.IsPresent(tbKategori);
        }

        private bool FeedInputValid()
        {
            return Validater.IsPresent(tbUrl)
                   //&& Validater.IsValidRss(tbUrl.Text).Result
                   && Validater.DropDownBoxIsSelected(cbFrekvens)
                   && Validater.DropDownBoxIsSelected(cbKategori);
        }
    }
}
