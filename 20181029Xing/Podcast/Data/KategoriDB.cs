using Podcast.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Podcast.Data
{
    class KategoriDB
    {
        private const string path = @"..\..\XMLFiles\Kategorier.xml";

        public static void saveKategori(List<Kategori> kategoris)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("   ");

            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Kategorier");

            foreach (Kategori kategori in kategoris)
            {
                xmlOut.WriteStartElement("Kategori");
                xmlOut.WriteElementString("Namn", kategori.Namn);
                xmlOut.WriteEndElement();
            }
            xmlOut.WriteEndElement();
            xmlOut.Close();
        }

        public static List<Kategori> GetKategorier()
        {
            List<Kategori> kategoris = new List<Kategori>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            XmlReader xmlin = XmlReader.Create(path, settings);

            if (xmlin.ReadToDescendant("Kategori"))
            {
                do
                {
                    Kategori kategori = new Kategori();
                
                    xmlin.ReadStartElement("Kategori");
                    kategori.Namn = xmlin.ReadElementContentAsString();
                    kategoris.Add(kategori);
                }
                while (xmlin.ReadToNextSibling("Kategori"));
            }
            xmlin.Close();
            return kategoris;

        }
    }
}
