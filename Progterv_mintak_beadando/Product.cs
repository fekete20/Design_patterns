using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Progterv_mintak_beadando
{
    abstract class Product
    {
        private string _name;
        private string _category;
        private int _price;
        private int _stock;

        public Product(string name, string category, int price, int stock)
        {
            _name = name;
            _category = category;
            _price = price;
            _stock = stock;
        }

        public Product(string category)
        {
            _category = category;
        }

        public Product() { }
      
        public string Name { get { return _name; } }
        public string Category { get { return _category; } } 
        public int Price { get { return _price; } }

        public int Stock { get { return _stock;  } }

        public void SetName(string name)
        {
            this._name = name;
        }
        public void SetCategory(string category)
        {
            this._category = category;
        }
        public void SetPrice(int price)
        {
            this._price = price;
        }

        public void SetStock(int stock)
        {
            this._stock = stock;
        }

        public void DecreasePrice(int percent)
        {
            this.SetPrice((int) (this.Price - (this.Price * ((double) percent / 100))));
        }

        public void IncreasePrice(int percent)
        {
            this.SetPrice((int)(this.Price + (this.Price *  ((double) percent / 100))));
        }

        public abstract void DisplayProduct();

    }
}
