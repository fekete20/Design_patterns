using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    class Drink : Product
    {
        private double _capacity;
        private DrinkPackaging _drinkPackaging;
        private double _alcoholVolume;

        public Drink(string name, int price, int stock, double capacity, DrinkPackaging dringPackaging, double alcoholVolume) : base(name, "drink", price, stock)
        {
            _capacity = capacity;
            _drinkPackaging = dringPackaging;
            _alcoholVolume = alcoholVolume;
        }

        public Drink() : base("drink") { }

        public double Capacity { get { return _capacity; } }
        public DrinkPackaging DrinkPackaging { get { return _drinkPackaging; } }
        public double AlcoholVolume { get { return _alcoholVolume; } }

        public void SetCapacity(double capacity)
        {
            this._capacity = capacity;
        }
        public void SetDrinkPackaging(DrinkPackaging drinkPackaging)
        {
            this._drinkPackaging = drinkPackaging;
        }

        public void SetDrinkPackaging(int number)
        {
            if(number == 0)
            {
                this._drinkPackaging = DrinkPackaging.BOTTLE;
            }
            if (number == 1)
            {
                this._drinkPackaging = DrinkPackaging.CUP;
            }
        }
        public void SetAlcoholVolume(double alcoholVolume)
        {
            this._alcoholVolume = alcoholVolume;
        }

        public override void DisplayProduct()
        {
            ProductDecorator productDecorator = new ProductDecorator(this);
            productDecorator.DisplayProduct();
        }
    }
}
