using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZADANIE1
{
    static class Menu
    {
        public static void MainMenu()
        {
            bool endProgram = false;
            AutoBazar.OpenFile(AutoBazar.FileName);
            Console.WriteLine("+++AUTOBAZAR+++\n");
            while (endProgram == false)
            {
                Console.WriteLine("Vyber si moznost:");
                Console.WriteLine("1 - Otvor zoznam");
                Console.WriteLine("2 - Pridaj auto");
                Console.WriteLine("3 - Vymaz auto");
                Console.WriteLine("4 - Zmen parametre auta");
                Console.WriteLine("8 - Ulozit a pokracovat");
                Console.WriteLine("9 - Ulozit a koniec");
                Console.WriteLine("0 - Zahodit zmeny a koniec\n");
                bool isInt = int.TryParse(Console.ReadLine(), out int choice);
                Console.WriteLine();
                if (!isInt)
                {
                    Console.WriteLine("Zadana nespravna hodnota, moznost neexistuje\n");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Id\tRok\tKm\tZnacka\tTyp\tPalivo\tCena\tMesto\tDvere\tHavarovane");
                        Console.WriteLine(AutoBazar.WriteAllCarsToString());
                        break;
                    case 2:
                        AutoBazar.AddCar();
                        break;
                    case 3:
                        AutoBazar.DeleteCar();
                        break;
                    case 4:
                        AutoBazar.ChangeCar();
                        break;
                    case 8:
                        AutoBazar.SaveToFile(AutoBazar.WriteAllCarsToString());
                        break;
                    case 9:
                        AutoBazar.SaveToFile(AutoBazar.WriteAllCarsToString());
                        endProgram = true;
                        break;
                    case 0:
                        Console.WriteLine("Naozaj chcete zahodit vykonane zmeny? 1 - nie / 2 - ano");
                        int answer = int.Parse(Console.ReadLine());
                        if (answer == 1)
                        {
                            break;
                        }
                        else
                        {
                            endProgram = true;
                            break;
                        }
                       
                    default:
                        Console.WriteLine("Zadana nespravna hodnota, moznost neexistuje\n");
                        break;
                }
            }
        }
        
    }
}
