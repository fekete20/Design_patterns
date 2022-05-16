using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Progterv_mintak_beadando
{
    class JSONHandler : IProductFacade
    {
        public void WriteToJSON(List<Product> products)
        {
            var json = "";
            StreamWriter sw = new StreamWriter("../../test.json");
            foreach (Product product in products)
            {
                json = new JavaScriptSerializer().Serialize(product);
                sw.WriteLine(json);
            }
            sw.Close();
        }

        public List<Product> ReadFromJSON(string path, string filename)
        {
            List<Product> products = new List<Product>();
            ProductFactory productFactory = new ProductFactory();

            StreamReader sr = new StreamReader(path + filename);
            string line = "";
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            while ((line = sr.ReadLine()) != null)
            {
                dynamic json = javaScriptSerializer.DeserializeObject(line);
                Product product = productFactory.GetInstance(json["Category"]);

                if (product is Drink)
                {
                    product.SetName(json["Name"]);
                    product.SetPrice(json["Price"]);
                    product.SetStock(json["Stock"]);
                    ((Drink)product).SetCapacity(Decimal.ToDouble(json["Capacity"]));
                    ((Drink)product).SetDrinkPackaging((DrinkPackaging)json["DrinkPackaging"]);
                    ((Drink)product).SetAlcoholVolume(Decimal.ToDouble(json["AlcoholVolume"]));
                    products.Add(product);
                }

                if (product is Food)
                {
                    product.SetName(json["Name"]);
                    product.SetPrice(json["Price"]);
                    product.SetStock(json["Stock"]);
                    ((Food)product).SetWeight(Decimal.ToDouble(json["Weight"]));
                    ((Food)product).SetExpiration(json["Expiration"]);
                    products.Add(product);
                }
            }
            sr.Close();
            return products;
        }

        public void DecreasePrice(int percent)
        {
            throw new NotImplementedException(); // implemented in Product
        }

        public void IncreasePrice(int percent)
        {
            throw new NotImplementedException(); // implemented in Product
        }
    }
}
