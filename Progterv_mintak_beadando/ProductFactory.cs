using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    class ProductFactory : IProductFactory
    {
        public Product GetInstance(string category)
        {
            if(category == null)
            {
                return null;
            }
            if(category.ToLower().Equals("food"))
            {
                return new Food();
            }
            if(category.ToLower().Equals("drink"))
            {
                return new Drink();
            }

            return null;

        }
    }
}
