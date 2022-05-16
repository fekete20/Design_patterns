using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    class ProductDecorator : Product
    {
        protected Product product;

        public ProductDecorator(Product product)
        {
            this.product = product;
        }


        public override void DisplayProduct()
        {
                if (this.product is Food)
                {
                    Console.WriteLine("Food:\t name: {0}\t price: {1}\t stock: {2}\t weight: {3}\t expiration: {4}", this.product.Name, this.product.Price, this.product.Stock, ((Food) this.product).Weight, ((Food) this.product).Expiration);
                }

                if (this.product is Drink)
                {
                    Console.WriteLine("Drink:\t name: {0}\t price: {1}\t stock: {2}\t capacity: {3}\t drinkPackaging: {4}\t alcoholVolume: {5}", this.product.Name, this.product.Price, this.product.Stock, ((Drink) this.product).Capacity, ((Drink) this.product).DrinkPackaging, ((Drink) this.product).AlcoholVolume);
                }            
        }
    }
}
