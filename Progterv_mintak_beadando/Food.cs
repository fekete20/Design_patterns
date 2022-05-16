using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    class Food : Product
    {
        private double _weight;
        private DateTime _expiration;

        public Food(string name, int price, int stock, double weight, DateTime expiration) : base(name, "food", price, stock)
        {
            _weight = weight;
            _expiration = expiration;
        }

        public Food() : base("food") { }

        public double Weight { get { return _weight; } }
        public DateTime Expiration { get { return _expiration; } }

        public void SetWeight(double weight)
        {
            this._weight = weight;
        }
        public void SetExpiration(DateTime dateTime)
        { 
            this._expiration = dateTime; 
        }

        public override void DisplayProduct()
        {
            ProductDecorator productDecorator = new ProductDecorator(this);
            productDecorator.DisplayProduct();
        }
    }
}
