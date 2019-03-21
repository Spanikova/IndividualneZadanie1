using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZADANIE1
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoBazar.OpenFile(AutoBazar.fileName);
            //AutoBazar.AddCar();
            AutoBazar.DeleteCar();
            AutoBazar.SaveToFile(AutoBazar.WriteCarsToString());
        }
    }
}
