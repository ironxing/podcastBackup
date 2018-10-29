using Podcast.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Podcast.Data
{
    class AvsnittDB
    {
        public static void saveAvsnitt(List<Avsnitt> avsnitts, string fileName)
        {
            string path = @"..\..\XMLFiles\Avsnitt_" + fileName + ".xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("   ");

            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Kategorier");

            foreach (var avsnitt in avsnitts)
            {
                xmlOut.WriteStartElement("Avsnitt");
                xmlOut.WriteElementString("Titel", avsnitt.Titel);
                xmlOut.WriteElementString("Description", avsnitt.Description);
                xmlOut.WriteElementString("URI", avsnitt.URI);
                xmlOut.WriteElementString("Length", avsnitt.Length);
                xmlOut.WriteEndElement();
            }
            xmlOut.WriteEndElement();
            xmlOut.Close();
        }

        public static List<Avsnitt> GetAvsnitt(string fileName)
        {
            string path = @"..\..\XMLFiles\Avsnitt_" + fileName + ".xml";

            List<Avsnitt> avsnitts = new List<Avsnitt>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            XmlReader xmlin = XmlReader.Create(path, settings);

            if (xmlin.ReadToDescendant("Avsnitt"))
            {
                do
                {
                    Avsnitt avsnitt = new Avsnitt();

                    xmlin.ReadStartElement("Avsnitt");
                    avsnitt.Titel = xmlin.ReadElementContentAsString();
                    avsnitt.Description = xmlin.ReadElementContentAsString();
                    avsnitt.URI = xmlin.ReadElementContentAsString();
                    avsnitt.Length = xmlin.ReadElementContentAsString(); 
                    avsnitts.Add(avsnitt);
                }
                while (xmlin.ReadToNextSibling("Avsnitt"));
            }
            xmlin.Close();
            return avsnitts;
        }
    }
}

