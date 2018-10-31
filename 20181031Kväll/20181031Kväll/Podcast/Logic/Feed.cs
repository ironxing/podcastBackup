using Podcast.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.Logic
{


    public class Feed
    {
        public string Titel { get; set; }
        public int AntalAvsnitt { get; set; }
        public int Frekvens { get; set; }
        public string Url { get; set; }
        public string Kategori { get; set; }

        public List<Avsnitt> List {get; set;}

        public List<Avsnitt> SortedList
        {
            get
            {
                return List.OrderBy(i => i.Titel).ToList();
            }
        }

        public Feed(int Frekvens, string Url, string Kategori)
        {
            this.Frekvens = Frekvens;
            this.Url = Url;
            this.Kategori = Kategori;
            this.List = new List<Avsnitt>();
        }

        public Feed()
        {

        }

        public void ChangeKategori(string newKategori)
        {
            this.Kategori = newKategori;
        }

        public void GetFeedInfo()
        {
            FeedDB.GetFeedInfo(this);
        }

        public List<Avsnitt> GetAvsnitts()
        {
            var task  = FeedDB.GetAvsnitts(this.Url);
            task.Wait();
            return task.Result;
        }

        public void saveAvsnitt()
        {
            AvsnittDB.saveAvsnitt(this.List, this.Titel);
        }
    }
}
