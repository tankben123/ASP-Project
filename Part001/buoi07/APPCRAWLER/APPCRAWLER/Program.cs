using APPCRAWLER;
using HtmlAgilityPack;
string url = "https://www.tulucmall.com/BookStore/Sales/Item/3d54ec28-e0cb-43eb-9ef2-de4616d49cc9";

HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load(url);
HtmlNode title = doc.DocumentNode.SelectSingleNode("//*[@id=\"bodysection\"]/div[2]/div[1]/div/div[2]");
System.Console.WriteLine(title.InnerText);

HtmlNode img = doc.DocumentNode.SelectSingleNode("//*[@id=\"LeftPanel\"]/div[1]/img");
System.Console.WriteLine(img.GetAttributeValue("src", null));


HtmlNodeCollection items = doc.DocumentNode.SelectNodes("//*[@id=\"itemInfo\"]/div");


Dictionary<string, APPCRAWLER.Attribute> dict = new Dictionary<string, APPCRAWLER.Attribute>();
string[] producer = items[0].InnerText.Split(" - ");


string key = producer[0];

if (dict.ContainsKey(key))
{
    var obj = new APPCRAWLER.Attribute()
    {
        Name = producer[0],
        NameVI = producer[1],
    };

    AttributeRepository.Add(obj);
    dict[key] = obj;
}    

List<Specification> list = new List<Specification>();
Random random = new Random();
int productId = random.Next();

list.Add(new Specification()
{
    ProductId = productId,
    AttributeId = dict[producer[0]].Id
});

string[] author = items[2].InnerText.Split(" - ");

key = author[1];
if (dict.ContainsKey(key))
{
    var obj = new APPCRAWLER.Attribute()
    {
        Name = author[1],
        NameVI = author[0]
    };

    AttributeRepository.Add(dict[author[1]]);
    dict[key] = obj;
}    

list.Add(new Specification()
{
    ProductId = productId,
    AttributeId = dict[author[1]].Id
});

string price = items[5].InnerText.Trim().Replace("$", "");

Product product = new Product()
{
    Id = productId,
    Title = title.InnerText.Trim(),
    CategoryId = 1,
    ImageUrl = img.GetAttributeValue("src", null).Trim(),
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
        if (dict.ContainsKey(key))
        {
            var obj = new APPCRAWLER.Attribute()
            {
                Name = key,
                NameVI = arr[0]
            };
            AttributeRepository.Add(obj);
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
ProductRepository.Add(product);

//dang toi phut 39
