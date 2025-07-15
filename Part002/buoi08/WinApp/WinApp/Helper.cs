using DAL;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace WinApp
{
    internal class Helper
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
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

        public static int AddBookUrls(string url, Dictionary<string, DAL.Attribute> dict)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNode? title = doc.DocumentNode.SelectSingleNode("//*[@id=\"bodysection\"]/div[2]/div[1]/div/div[2]");
            //System.Console.WriteLine(title.InnerText);

            HtmlNode? img = doc.DocumentNode.SelectSingleNode("//*[@id=\"LeftPanel\"]/div[1]/img");
            //System.Console.WriteLine(img.GetAttributeValue("src", null));
            HtmlNodeCollection? items = doc.DocumentNode.SelectNodes("//*[@id=\"itemInfo\"]/div");

            if (items == null)
                return 0;

            //Dictionary<string, DAL.Attribute> dict = new Dictionary<string, DAL.Attribute>();
            string[] producer = items[0].InnerText.Split(" - ");

            int count = 0;
            using (BookStoreContext context = new BookStoreContext(connectionString))
            {
                SiteProvider provider = new SiteProvider(context);

                string key = producer[0].Trim();
                if (!dict.ContainsKey(key))
                {
                    var obj = new DAL.Attribute()
                    {
                        Name = producer[0].Trim(),
                        NameVI = producer[1].Trim(),
                    };

                    count += provider.Attribute.Add(obj);
                    dict[key] = obj;
                }

                List<Specification> list = new List<Specification>();
                Random random = new Random();
                int productId = random.Next();

                list.Add(new Specification()
                {
                    ProductId = productId,
                    AttributeId = dict[key].Id,
                    Value = items[1].InnerText.Trim()
                });

                string[] author = items[2].InnerText.Split(" - ");


                key = author[author.Length - 1].Trim();
                if (!dict.ContainsKey(key))
                {
                    var obj = new DAL.Attribute()
                    {
                        Name = key,
                        NameVI = author[0].Trim()
                    };

                    count += provider.Attribute.Add(obj);
                    dict[key] = obj;
                }

                list.Add(new Specification()
                {
                    ProductId = productId,
                    AttributeId = dict[key].Id,
                    Value = items[3].InnerText.Trim()
                });

                string price = items[5].InnerText.Trim().Replace("$", "");

                Product product = new Product()
                {
                    Id = productId,
                    Title = title.InnerText.Trim(),
                    CategoryId = 1,
                    ImageUrl = Path.GetFileName(img.GetAttributeValue("src", null).Trim()),
                    UnitPrice = Convert.ToDecimal(price),

                };

                //Specification

                HtmlNodeCollection specifications = doc.DocumentNode.SelectNodes("//*[@id=\"description\"]/div");

                int n = specifications.Count / 2;
                for (int i = 0; i < n; i++)
                {
                    //phan tieu de
                    string[] arr = specifications[2 * i].InnerText.Split(" - ");
                    key = arr[arr.Length - 1].Trim();

                    if (key == "ISBN")
                    {
                        product.ISBN = specifications[2 * i + 1].InnerText.Trim();
                    }
                    else
                    {
                        if (!dict.ContainsKey(key))
                        {
                            var obj = new DAL.Attribute()
                            {
                                Name = key,
                                NameVI = arr[0].Trim()
                            };
                            count += provider.Attribute.Add(obj);
                            dict[key] = obj;
                        }

                        list.Add(new Specification()
                        {
                            ProductId = productId,
                            AttributeId = dict[key].Id,
                            Value = specifications[2 * i + 1].InnerText.Trim()
                        });
                    }

                    //phan thong tin 
                    //specifications[2 * i + 1].InnerText.Trim();
                }
                count += provider.Product.Add(product);
                count += provider.Specification.Add(list);
                return count;
                //dang toi phut 39
            }

        }

    }
}
