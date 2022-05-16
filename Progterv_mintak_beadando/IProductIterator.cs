using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    interface IProductIterator
    {
        Boolean HasNext();
        Product GetProduct();
        void ResetIterator();
        List<Product> GetProducts();
    }
}
