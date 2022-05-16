using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    class ProductIterator : IProductIterator
    {
        private int index;
        private List<Product> products;

        public ProductIterator(List<Product> products)
        {
            this.products = products;
        }

        public List<Product> GetProducts()
        {
            return products;
        }
        public void ResetIterator()
        {
            this.index = 0;
        }

        public Product GetProduct()
        {
            return products[this.index++];       
        }
        
        public Boolean HasNext()
        {
            if (this.index < products.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
