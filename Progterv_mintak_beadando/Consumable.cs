using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    class Consumable : ProductDecorator
    {
        protected List<string> consumers = new List<string>();

        public Consumable(Product product) : base(product)
        {

        }

        public void ConsumeItem(string name)
        {
            consumers.Add(name);
            product.SetStock(product.Stock - 1);
        }

        public override void DisplayProduct()
        {
            Console.WriteLine();
            base.DisplayProduct();

            foreach(string consumer in consumers)
            {
                Console.Write("Consumer: {0}\n", consumer);
            }
        }
    }
}
