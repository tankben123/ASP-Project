using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp
{
    internal class Helper
    {
        public static List<string> GetUrls(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@id=\"iconscontainer\"]/div/div[@class=\"product-icon\"]");

            List<string> list = new List<string>();

            foreach (var item in nodes)
            {
                string id = item.GetAttributeValue("id", null);
                if (!string.IsNullOrEmpty(id))
                    list.Add(id);
            }
            return list;
        }
    }
}
