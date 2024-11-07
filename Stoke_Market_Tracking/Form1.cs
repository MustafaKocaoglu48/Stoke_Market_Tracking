using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Stoke_Market_Tracking
{

    public partial class Form1 : Form
    {
        public int userId;
        public string dolarAlis;
        public string dolarSatis;
        public string euroAlis;
        public string euroSatis;


        public Form1()
        {
            InitializeComponent();
            this.userId = userId;
            this.Load += new System.EventHandler(this.Form1_Load);

        }
        private void doviz_Load()
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            dolarAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolarSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            euroAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doviz_Load();

            List<string> dovizKurlari = new List<string> { "USD", "EUR" };
            cmbDoviz.Items.AddRange(dovizKurlari.ToArray());

            cmbDoviz.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenDoviz = cmbDoviz.SelectedItem.ToString();
            label1.Text = secilenDoviz;

            switch (secilenDoviz)
            {
                case "USD":
                    label2.Text = "Alış: " + dolarAlis;
                    label3.Text = "Satış: " + dolarSatis;
                    break;
                case "EUR":
                    label2.Text = "Alış: " + euroAlis;
                    label3.Text = "Satış: " + euroSatis;
                    break;
                default:
                    label2.Text = "Alış: Bilinmiyor";
                    label3.Text = "Satış: Bilinmiyor";
                    break;
            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
