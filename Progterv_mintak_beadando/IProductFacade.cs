using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando
{
    interface IProductFacade
    {
        void DecreasePrice(int percent);
        void IncreasePrice(int percent); 
        List<Product> ReadFromJSON(string path, string filename);
        void WriteToJSON(List<Product> products);

    }
}
