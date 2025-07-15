using DAL;
using System.Configuration;
using System.Threading.Tasks;

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
            //nao can thi mo ra chay
            return;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            List<BookUrl> bookUrls;
            using (BookStoreContext context = new BookStoreContext(connectionString))
            {
                SiteProvider provider = new SiteProvider(context);
                bookUrls = provider.BookUrl.GetBookUrls();
                dataGridView1.DataSource = bookUrls;
            }

            Dictionary<string, DAL.Attribute> dict = new Dictionary<string, DAL.Attribute>();

            await Task.Run(() =>
            {
                int count = 0;
                int item_num = 0;
                foreach (var item in bookUrls)
                {
                    item_num += 1;
                    this.Invoke((MethodInvoker)(() => label3.Text = $"{item_num}/{bookUrls.Count}"));

                    count += Helper.AddBookUrls(Root + item.Id, dict);

                    this.Invoke((MethodInvoker)(() => textBox1.Text = count.ToString()));
                }
            });
        }
    }
}
