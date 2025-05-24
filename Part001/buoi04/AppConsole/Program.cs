using AppConsole;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Security.Cryptography;
using System.Text.Json;

string path = "../../../books_titles.json";
using (StreamReader sr = new StreamReader(path))
{
    string data = sr.ReadToEnd();
    //Console.WriteLine(data.Length);
    Book? book = JsonSerializer.Deserialize<Book>(data);
    if (book != null)
    {
        //ADO net
        //int c = 0;
        //DataTable table = new DataTable();
        //string[] columns = { "BookId", "Title", "ImageUrl", "Ratings", "Url" };

        //foreach (var item in columns)
        //    table.Columns.Add(item);

        //foreach (var item in book.book_id)
        //{
        //    DataRow row = table.NewRow();
        //    row["BookId"] = Convert.ToInt32(item.Value);
        //    row["Title"] = book.title[item.Key].Trim();
        //    row["ImageUrl"] = book.cover_image[item.Key].Trim();
        //    row["Ratings"] = book.ratings[item.Key];
        //    row["Url"] = book.url[item.Key].Trim();
        //    table.Rows.Add(row);
        //}

        //BookRepository repository = new BookRepository();
        //repository.Add(table);

        //entity framework
        List<Ebook> list = new List<Ebook>();
        foreach (var item in book.book_id)
        {
            Ebook obj = new Ebook()
            {
                Id = Convert.ToInt32(item.Value),
                Title = book.title[item.Key].Trim(),
                ImageUrl = book.cover_image[item.Key].Trim(),
                Ratings = book.ratings[item.Key],
                Url = book.url[item.Key].Trim()
            };
            list.Add(obj);
        }

        using (StoreContext context = new StoreContext())
        {
            context.Ebooks.AddRange(list);
            context.SaveChanges();
        }    
    }
}