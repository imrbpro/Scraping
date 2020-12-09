using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScrapWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            //HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.paci.gov.kw/");
            //string PACI = "";
            //var data = doc.DocumentNode.SelectNodes("//div");


            HtmlAgilityPack.HtmlDocument doc = web.Load("https://homeshopping.pk/categories/Fresh-Produce-Karachi/");
            string itemName = "";
            string price = "";
            int i = 0;
            var toScrap = doc.DocumentNode.SelectNodes("//div[contains(@class, \'ProductsList\')]");
            foreach (var item in toScrap)
            {
                Response.Write(item.InnerHtml);

                itemName = item.SelectNodes("//div[contains(@class, \'padx8\')]/h5/a")[i].InnerText;
                price = item.SelectNodes("//div[contains(@class,\'ActualPrice\')]")[i].InnerText;
                Response.Write("<br/> <h1>One Item Extraction ... </h1> <br/> <div><h2>" + itemName + "</h2><br/><h3>" + price + "</h3>");
                i += 1;
            }
        }
    }
}