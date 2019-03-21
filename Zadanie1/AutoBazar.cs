using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZADANIE1
{
    class AutoBazar
    {
        private static bool isCorrectInput = false;
        public static int MaxId { get; set; }
        public static string FileName
        {
            get { return "auta.txt"; }
        }
        private static List<Car> cars = new List<Car>(100);


        public static List<Car> OpenFile(string FileName)
        {
            if (!File.Exists(FileName))
            {
                FileStream fs = File.Create(FileName);
                fs.Close();
            }
            List<string> lines = new List<string>(100);
            lines = File.ReadAllLines(FileName).ToList();
            string[] zaznam = new string[10];
            foreach (string line in lines)
            {
                zaznam = line.Split('\t');
                Car car = new Car(
                    int.Parse(zaznam[0]),
                    int.Parse(zaznam[1]),
                    int.Parse(zaznam[2]),
                    zaznam[3],
                    zaznam[4],
                    (Car.Fuel)Enum.Parse(typeof(Car.Fuel), zaznam[5]),
                    decimal.Parse(zaznam[6]),
                    zaznam[7],
                    int.Parse(zaznam[8]),
                    bool.Parse(zaznam[9])
                    );
                cars.Add(car);
                if (car.Id > MaxId)
                {
                    MaxId = car.Id;
                }
            }
            return cars;
        }

        public static void SaveToFile(string text)
        {
            File.WriteAllText(FileName, text);
        }

        public static void AddCar()
        {
            Console.WriteLine("Zadaj parametre auta");
            int id = MaxId + 1;
            int manufactureYear = EnterManufactureYear();
            int km = EnterKm();
            string brand = EnterBrand();
            string type = EnterType();
            Car.Fuel fuelType = EnterFuelType();
            decimal price = EnterPrice();
            string cityOfSale = EnterCityOfSale();
            int doorCount = EnterDoorCount();
            bool isCrashed = EnterIsCrashed();
            Car car = new Car(id, manufactureYear, km, brand, type, fuelType, price, cityOfSale, doorCount, isCrashed);
            cars.Add(car);
            Console.WriteLine("Auto bolo pridane.");
            MaxId++;
        }

        public static string WriteCarToString(Car car)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(car.Id.ToString() + '\t');
            sb.Append(car.ManufactureYear.ToString() + '\t');
            sb.Append(car.Km.ToString() + '\t');
            sb.Append(car.Brand.ToString() + '\t');
            sb.Append(car.Type.ToString() + '\t');
            sb.Append(car.FuelType.ToString() + '\t');
            sb.Append(car.Price.ToString() + '\t');
            sb.Append(car.CityOfSale.ToString() + '\t');
            sb.Append(car.DoorCount.ToString() + '\t');
            sb.AppendLine(car.IsCrashed.ToString());
            return sb.ToString();
        }

        public static string WriteAllCarsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Car car in cars)
            {
                sb.Append(WriteCarToString(car));
            }
            return sb.ToString();
        }

        public static void DeleteCar()
        {
            int selectedId = 0;
            do
            {
                Console.WriteLine("Zadaj id auta, ktore chces vymazat:");
                isCorrectInput = int.TryParse(Console.ReadLine(), out selectedId) && (selectedId >= 0);
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. ID auta musi byt kladna ciselna hodnota");
                }
            }
            while (!isCorrectInput);

            bool lineToDeleteExists = false;
            foreach (Car car in cars)
            {
                if (car.Id == selectedId)
                {
                    cars.Remove(car);
                    lineToDeleteExists = true;
                    Console.WriteLine($"Vymazanie auta s id {selectedId} prebehlo uspesne.");
                    break;
                }
            }
            if (!lineToDeleteExists)
            {
                Console.WriteLine("Neexistuje zaznam s tymto id. Zaznam sa nevymazal.");
                Console.ReadLine();
            }
        }

        public static void ChangeCar()
        {
            int selectedId = 0;
            bool idExists = false;

            do
            {
                Console.WriteLine("Zadaj id auta, ktore chces upravit:");
                isCorrectInput = int.TryParse(Console.ReadLine(), out selectedId) && (selectedId >= 0);
                foreach (Car car in cars)
                {
                    if (car.Id == selectedId)
                    {
                        idExists = true;
                    }
                }
                if (!idExists)
                {
                    Console.WriteLine("Zadane id neexistuje");
                }
                if (!isCorrectInput)
                {
                    Console.WriteLine("ID auta musi byt kladna ciselna hodnota");
                }

            }
            while (!isCorrectInput || !idExists);
            Console.WriteLine("Ktory parameter chces zmenit?");
            Console.WriteLine("1 - rok vyroby");
            Console.WriteLine("2 - pocet najazdenych km");
            Console.WriteLine("3 - znacka");
            Console.WriteLine("4 - typ auta");
            Console.WriteLine("5 - druh paliva: 1 - benzin / 2 - diesel / 3 - hybrid / 4 - plyn / 5 - elektro:");
            Console.WriteLine("6 - cena");
            Console.WriteLine("7 - mesto, kde sa predava");
            Console.WriteLine("8 - pocet dveri: 3 / 5");
            Console.WriteLine("9 - je havarovane? 1 - nie / 2 - ano");
            int choice = 0;
            do
            {
                isCorrectInput = int.TryParse(Console.ReadLine(), out choice) && (choice >= 1 && choice <= 9);
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. Vyber si z moznosti 1 - 9");
                }
            }
            while (!isCorrectInput);
            Console.WriteLine("Zadaj novu hodnotu:");
            foreach (Car car in cars)
            {
                if (car.Id == selectedId)
                {
                    switch (choice)
                    {
                        case 1:
                            car.ManufactureYear = EnterManufactureYear();
                            break;
                        case 2:
                            car.Km = EnterKm();
                            break;
                        case 3:
                            car.Brand = EnterBrand();
                            break;
                        case 4:
                            car.Type = EnterType();
                            break;
                        case 5:
                            car.FuelType = EnterFuelType();
                            break;
                        case 6:
                            car.Price = EnterPrice();
                            break;
                        case 7:
                            car.CityOfSale = EnterCityOfSale();
                            break;
                        case 8:
                            car.DoorCount = EnterDoorCount();
                            break;
                        case 9:
                            car.IsCrashed = EnterIsCrashed();
                            break;
                    }
                    break;
                }
            }
        }


        public static int EnterManufactureYear()
        {
            int manufactureYear = 0;
            do
            {
                Console.Write("Rok vyroby: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out manufactureYear) && (manufactureYear >= 1950 && manufactureYear <= DateTime.Now.Year);
                if (!isCorrectInput)
                {
                    Console.WriteLine($"Zadana nespravna hodnota. Rok musi byt ciselna hodnota medzi 1950 a {DateTime.Now.Year}");
                }
            } while (!isCorrectInput);
            return manufactureYear;
        }

        public static int EnterKm()
        {
            int km = 0;
            do
            {
                Console.Write("Pocet najazdenych kilometrov: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out km) && km >= 0;
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. Pocet najazdenych km musi byt kladna ciselna hodnota");
                }
            }
            while (!isCorrectInput);
            return km;
        }

        public static string EnterBrand()
        {
            string brand = "";
            do
            {
                Console.Write("Znacka: ");
                brand = Console.ReadLine().Trim();
                isCorrectInput = brand.Length > 0;
                if (!isCorrectInput)
                {
                    Console.WriteLine("Znacka nebola zadana");
                }
            }
            while (!isCorrectInput);
            return brand;
        }

        public static string EnterType()
        {
            string type = "";
            do
            {
                Console.Write("Typ auta: ");
                type = Console.ReadLine().Trim();
                isCorrectInput = type.Length > 0;
                if (!isCorrectInput)
                {
                    Console.WriteLine("Typ auta nebol zadany");
                }
            }
            while (!isCorrectInput);
            return type;
        }

        public static Car.Fuel EnterFuelType()
        {
            int fuel = 0;
            do
            {
                Console.Write("Druh paliva: 1 - benzin / 2 - diesel / 3 - hybrid / 4 - plyn / 5 - elektro: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out fuel) && (fuel >= 1 && fuel <= 5);
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. Vyberte si z moznosti  1 - 5 ");
                }
            }
            while (!isCorrectInput);
            Car.Fuel fuelType = (Car.Fuel)fuel - 1;
            return fuelType;
        }

        public static decimal EnterPrice()
        {
            decimal price = 0;
            do
            {
                Console.Write("Cena: ");
                isCorrectInput = decimal.TryParse(Console.ReadLine(), out price) && price > 0;
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. Cena musi byt cislo vacsie ako 0");
                }
            }
            while (!isCorrectInput);
            return price;
        }

        public static string EnterCityOfSale()
        {
            string cityOfSale = "";
            do
            {
                Console.Write("Mesto, kde sa predava: ");
                cityOfSale = Console.ReadLine().Trim();
                isCorrectInput = cityOfSale.Length > 0;
                if (!isCorrectInput)
                {
                    Console.WriteLine("Predajne miesto nebolo zadane");
                }
            }
            while (!isCorrectInput);
            return cityOfSale;
        }

        public static int EnterDoorCount()
        {
            int doorCount = 0;
            do
            {
                Console.Write("Pocet dveri: 2 - 5: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out doorCount) && (doorCount >= 2 && doorCount <= 5);
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. Pocet dveri musi byt ciselna hodnota od 2 do 5");
                }
            }
            while (!isCorrectInput);
            return doorCount;
        }

        public static bool EnterIsCrashed()
        {
            bool isCrashed = false;
            do
            {
                Console.Write("Je havarovane? 1 - nie / 2 - ano: ");
                int havarovane = 0;
                isCorrectInput = int.TryParse(Console.ReadLine(), out havarovane) && (havarovane == 1 || havarovane == 2);
                if (havarovane == 2)
                {
                    isCrashed = true;
                }
                if (!isCorrectInput)
                {
                    Console.WriteLine("Zadana nespravna hodnota. Vyber si z ponuknutych moznosti.");
                }
            }
            while (!isCorrectInput);
            return isCrashed;
        }

    }
}
