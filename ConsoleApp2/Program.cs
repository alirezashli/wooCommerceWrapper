using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllProduct1();
        }

        public static async void GetOneProduct()
        {
            var key = "ck_11eedd67dd05dadef7e9e3e5142d34536e6b5c4e";
            var secret = "cs_bf52a8cf72941b774a9dd3e8ea1ea7314f67324c";
            RestAPI rest = new RestAPI("http://jivori.com/wp-json/wc/v3/", key, secret);
            WCObject wc = new WCObject(rest);
            var productsTemp = wc.Product.Get(31727).Result;
            Console.WriteLine("Product Name=" + productsTemp.name);
        }

        public static async void EditProduct()
        {
            var key = "ck_11eedd67dd05dadef7e9e3e5142d34536e6b5c4e";
            var secret = "cs_bf52a8cf72941b774a9dd3e8ea1ea7314f67324c";
            RestAPI rest = new RestAPI("http://jivori.com/wp-json/wc/v3/", key, secret);
            WCObject wc = new WCObject(rest);
            //Product Pr = wc.Product.Get(31727).Result;
            //Console.WriteLine("Product Name=" + Pr.name);
            Product Pr = new Product();
            Pr.description = "یه کتونی فوق العاده با کیفیت و شیک با طراحی مدرن و پر طرفدار، استفاده از بافت کشی با 2 طرح متفاوت ریلی و شبکه ای به صورت یک تیکه ، بافت برند این محصول با رنگ تیره در کنار کفش  و نیز بافت شبکه ای 2 رنگ بر روی ساق کفش که ترکیب دو رنگ متفاوت طوسی و صورتی هارمونی رنگی چشم نوازی ایجاد کرده ، جنس اشبالت تیکه دوزی شده بر روی زبانه و پشت کار باعث مقاومت شده ، جا بندی های تعبیه شده در رویه کفش ، استفاده از فناوری دایکات در کناره های کار و چاپ های روی زبانه و پشت کار همچنین زیره ی ریلی ، طرح کپسولی و 2 تیکه ی این کتونی  باعث شده تا ما این کتونی شیک و راحت رو به تمامی خانوم های باسلیقه و به روز پیشنهاد کنیم  .";
            Pr.description = "Test it";
            Pr = wc.Product.Update(31727, Pr).Result;
        }

        public static async void AddProduct()
        {
            var key = "ck_11eedd67dd05dadef7e9e3e5142d34536e6b5c4e";
            var secret = "cs_bf52a8cf72941b774a9dd3e8ea1ea7314f67324c";
            RestAPI rest = new RestAPI("http://jivori.com/wp-json/wc/v3/", key, secret);
            WCObject wc = new WCObject(rest);
            Product Pr = new Product();
            Pr.name = "تست API";
            Pr.sku = "9055";
            Pr.description = "تست می کنیم";
            var productsTemp = wc.Product.Add(Pr).Result;
            Console.WriteLine("Product Name=" + productsTemp.name);
        }

        public static async void GetAllProduct1()
        {
            var key = "ck_11eedd67dd05dadef7e9e3e5142d34536e6b5c4e";
            var secret = "cs_bf52a8cf72941b774a9dd3e8ea1ea7314f67324c";
            RestAPI rest = new RestAPI("http://jivori.com/wp-json/wc/v3/", key, secret);
            WCObject wc = new WCObject(rest);
            var dic = new System.Collections.Generic.Dictionary<string, string>();
            dic.Add("per_page", "100");
            int pageNumber = 1;
            dic.Add("page", pageNumber.ToString());
            var products = new List<Product>();

            bool endWhile = false;
            while (!endWhile)
            {
                var productsTemp =  wc.Product.GetAll(dic).Result;
                if (productsTemp.Count > 0)
                {
                    products.AddRange(productsTemp);
                    products.ForEach(p => {
                        Console.WriteLine(p.name);
                    });
                    pageNumber++;
                    dic["page"] = pageNumber.ToString();
                }
                else
                {
                    endWhile = true;
                }
            }
            Console.WriteLine("products.Count=" + products.Count);

        }

        public static async void GetAllProduct()
        {
            Console.WriteLine("GetAllProduct started!");
            try
            {
                var key = "ck_11eedd67dd05dadef7e9e3e5142d34536e6b5c4e";
                var secret = "cs_bf52a8cf72941b774a9dd3e8ea1ea7314f67324c";
                RestAPI rest = new RestAPI("https://jivori.com/wp-json/wc/v3/", key, secret);
                WCObject wc = new WCObject(rest);
                var ppp = new System.Collections.Generic.Dictionary<string, string>();

                wc.Product.GetAll(ppp);
                var products = await wc.Product.GetAll();
                var orders = await wc.Order.GetAll();

            }
            catch (Exception err)
            {

                Console.WriteLine(err.ToString());
            }
            Console.ReadKey();
        }
    }
}
