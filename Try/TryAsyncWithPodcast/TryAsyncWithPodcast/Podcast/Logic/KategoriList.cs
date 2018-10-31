using Podcast.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast.Logic
{
    class KategoriList
    {
        public delegate void KategoriChangeHandler();
        public event KategoriChangeHandler KateoriChanged;

        public List<Kategori> List { get; set; }
        
        public List<Kategori> SortedList
        {
            get
            {
                return List.OrderBy(i => i.Namn).ToList();
            }
        }

        public KategoriList()
        {
            List = new List<Kategori>();
        }
        
        public void Add(Kategori kategori)
        {
            List.Add(kategori);
            if (KateoriChanged != null)
            {
                KateoriChanged();
            }
        }

        public void changeKategoriNamn(string oldNamn, string newNamn)
        {
            var kategori = List.FirstOrDefault(i => i.Namn == oldNamn);
            kategori.Namn = newNamn;
            if (KateoriChanged != null)
            {
                KateoriChanged();
            }
        }

        public void deleteByNamn(string kategoriNamn)
        {
            int index = List.FindIndex(i => i.Namn == kategoriNamn);
            List.RemoveAt(index);
            if (KateoriChanged != null)
            {
                KateoriChanged();
            }
        }

        public void saveKategori()
        {
            KategoriDB.saveKategori(List);
        }

        public List<Kategori> fillKategori()
        {
            return KategoriDB.GetKategorier();
        }

        public bool NamnExistInList(string namn)
        {
            var kategori = List.FirstOrDefault(i => i.Namn == namn);
            if (kategori != null)
            {
                MessageBox.Show("Kategori finns redan i listan. Du kan ändra det genom att klicka på det i listan, göra ändringar och klicka på Ändra");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
