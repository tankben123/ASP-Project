using DAL;
using System.Configuration;

namespace WinApp
{
    public partial class Form1 : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
        string Root = "https://www.tulucmall.com/BookStore/Sales/Item/";
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnqueue_Click(object sender, EventArgs e)
        {
            int count = 0;
            HashSet<string> set = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            string seed = txtseed.Text.Trim();

            queue.Enqueue(seed);
            set.Add(seed);


            await Task.Run(() =>
            {
                while (queue.Count > 0)
                {
                    string elm = queue.Dequeue();
                    List<string> list = Helper.GetUrls(Root + elm);
                    foreach (var item in list)
                    {
                        if (!set.Contains(item))
                        {
                            set.Add(item);
                            queue.Enqueue(item);

                            this.Invoke((MethodInvoker)(() => txttotalrow.Text = set.Count.ToString()));
                        }
                    }
                }
                

                List<BookUrl> bookUrls = new List<BookUrl>();
                foreach (var item in set)
                {
                    bookUrls.Add(new BookUrl
                    {
                        Id = item
                    });
                }

                using (BookStoreContext context = new BookStoreContext(connectionString))
                {
                    SiteProvider provider = new SiteProvider(context);
                    int ret = provider.BookUrl.Add(bookUrls);
                    txttotalrow.Text = ret.ToString();
                }
            });

             
        }

    }
}
