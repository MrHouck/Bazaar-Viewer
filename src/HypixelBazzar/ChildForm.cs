using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
namespace HypixelBazzar
{
    public partial class ChildForm : Form
    {
        public string apiKey;
        public string product_id;
        public ChildForm(string title, string productId, string api_key)
        {
            InitializeComponent();
            label1.Text = title;
            apiKey = api_key;
            product_id = productId;
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

            string json = string.Empty;
            string url = @"https://api.hypixel.net/skyblock/bazaar?key=" + apiKey;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            var parsed = JObject.Parse(json);
            var sellPrice = parsed["products"][product_id]["quick_status"]["sellPrice"].ToString();
            var buyPrice = parsed["products"][product_id]["quick_status"]["buyPrice"].ToString();
            var sellVolume = parsed["products"][product_id]["quick_status"]["sellVolume"].ToString();
            var buyVolume = parsed["products"][product_id]["quick_status"]["buyVolume"].ToString();
            var sellOrders = parsed["products"][product_id]["quick_status"]["sellOrders"].ToString();
            var buyOrders = parsed["products"][product_id]["quick_status"]["buyOrders"].ToString();
            var buySummary = parsed["products"][product_id]["buy_summary"];
            var sellSummary = parsed["products"][product_id]["sell_summary"];
            
            foreach(var order in buySummary)
            {
                string amount = order["amount"].ToString();
                string pricePerUnit = order["pricePerUnit"].ToString();
                string orders = order["orders"].ToString();
                string finalString = "- " + pricePerUnit + " coins each | " + amount + "x in " + orders + " orders";
                listBox1.Items.Add(finalString);
            }
            foreach(var order in sellSummary)
            {
                string amount = order["amount"].ToString();
                string pricePerUnit = order["pricePerUnit"].ToString();
                string orders = order["orders"].ToString();
                string finalString = "- " + pricePerUnit + " coins each | " + amount + "x in " + orders + " orders";
                listBox2.Items.Add(finalString);
            }

            
            buyPrice.Replace('.', ',');
            sellPrice.Replace('.', ',');
            double bp = Convert.ToDouble(buyPrice);
            double sp = Convert.ToDouble(sellPrice);
            bp = Math.Round(bp,1);
            sp = Math.Round(sp,1);
            
            labelBuyPrice.Text = "Buy Price: " + bp.ToString();
            labelSellPrice.Text = "Sell Price: " + sp.ToString();
            labelBuyVolume.Text = "Buy Volume: " + buyVolume;
            labelSellVolume.Text = "Sell Volume: " + sellVolume;
        }
    }
}
