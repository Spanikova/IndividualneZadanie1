using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZADANIE1
{
    static class Menu
    {
        public static void mainMenu()
        {
            Console.WriteLine("AUTOBAZAR \t Vyber si moznost:");
            Console.WriteLine("1 - Otvor zoznam");
            Console.WriteLine("2 - Pridaj auto");
            Console.WriteLine("3 - Vymaz auto");
            Console.WriteLine("4 - Zmen parametre auta");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    //DOKONCIT
                    break;
                case 2:
                    AutoBazar.WriteCarsToString();
                    break;
                case 3:
                    //AutoBazar.DeleteCar();
                    break;
                case 4:
                    //AutoBazar.ChangeCar();
                    break;
            }
        }

        

        //public static int ChangeCarOptions()
        //{
            
            
        //    return choice;
        //}

        public static string ChangeCarValue(int choice)
        {
            Console.WriteLine("Zadaj novu hodnotu");
            string newValue = Console.ReadLine();
            switch (choice)
            {
                case 5:
                    Car.Palivo druhPaliva = (Car.Palivo)int.Parse(newValue);
                    newValue = druhPaliva.ToString();
                    break;
                case 9:
                    if (newValue.Equals(1))
                    {
                        newValue = "False";
                    }
                    else
                    {
                        newValue = "True";
                    }
                    break;
            }
            return newValue;
        }
    }
}
