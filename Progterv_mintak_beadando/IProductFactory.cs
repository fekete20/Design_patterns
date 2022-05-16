using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    internal interface IProductFactory
    {
        Product GetInstance(string category);
    }
}
