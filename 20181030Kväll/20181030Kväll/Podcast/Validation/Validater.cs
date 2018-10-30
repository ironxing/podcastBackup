using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Podcast.Validation
{
    public static class Validater
    {
        private static string Title = "";

        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                return false;
            }
            return true;
        }

        public static bool DropDownBoxIsSelected (ComboBox comboBox)
        {
            if (comboBox.SelectedIndex > -1)
            {
                return true;
            }
            else {
                MessageBox.Show("Vängligen välj från " + comboBox.Tag, Title);
                return false;
            }
        }

        public static bool IsValidRss(string url)
        {
            try
            {
                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));

                foreach (SyndicationItem item in feed.Items)
                {
                    Debug.Print(item.Title.Text);
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("RSS URL är inte giltig. Vänligen kontrollera du har skrivit i rätt RSS URL.");
                return false;
            }
        }

    }
}
