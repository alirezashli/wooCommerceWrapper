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


        public static async Product AddProducct()
        {

        }
    }
}
