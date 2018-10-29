using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.Logic
{
    public class Kategori
    {
        public string Namn { get; set; }

        public Kategori(string Namn)
        {
            this.Namn = Namn;   
        }

        public Kategori()
        {

        }
    }

}
