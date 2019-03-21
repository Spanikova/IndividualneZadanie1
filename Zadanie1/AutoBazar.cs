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
        public static int MaxId { get; set; }
        public static string fileName = "auta.txt";
        private static string tempFileName = "temp_auta.txt";
        public static List<Car> cars = new List<Car>(100);

        public static List<Car> OpenFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
            }
            List<string> lines = new List<string>(100);
            lines = File.ReadAllLines(fileName).ToList();
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
                    (Car.Palivo)Enum.Parse(typeof(Car.Palivo), zaznam[5]),
                    double.Parse(zaznam[6]),
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

        //public static void ReadLine(int line)
        //{

        //zaznam = lines[line].Split('\t');
        //}

        //public static int ReadId(int line)
        //{

        //    ReadLine(line);
        //    id = int.Parse(zaznam[0]);
        //    return id;
        //}

        public static void SaveToFile(string text)
        {
            FileStream fs = File.Create(tempFileName);
            fs.Close();
            File.WriteAllText(tempFileName, text);
            File.Delete(fileName);
            File.Move(tempFileName, fileName);
        }

        //public static int GenerateId()
        //{
        //    if (lines.Length > 0)
        //    {
        //        int lastLine = lines.Length - 1;
        //        id = ReadId(lastLine) + 1;
        //        return id;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}

        public static void AddCar()
        {
            Console.WriteLine("Zadaj parametre auta");
            int id = MaxId + 1;
            Console.Write("Rok vyroby: ");
            int rokVyroby = int.Parse(Console.ReadLine());
            Console.Write("Pocet najazdenych kilometrov: ");
            int pocetKm = int.Parse(Console.ReadLine());
            Console.Write("Znacka: ");
            string znacka = Console.ReadLine();
            Console.Write("Typ auta: ");
            string typAuta = Console.ReadLine();
            Console.Write("Druh paliva: 1 - benzin / 2 - diesel: ");
            int palivo = int.Parse(Console.ReadLine()) - 1;
            Car.Palivo druhPaliva = (Car.Palivo)palivo;
            Console.Write("Cena: ");
            int cena = int.Parse(Console.ReadLine());
            Console.Write("Mesto, kde sa predava: ");
            string predajneMiesto = Console.ReadLine();
            Console.Write("Pocet dveri: 3 / 5 : ");
            int pocetDveri = int.Parse(Console.ReadLine());
            Console.Write("Je havarovane? 1 - nie / 2 - ano: ");
            int havarovane = int.Parse(Console.ReadLine());
            bool jeHavarovane = false;
            if (havarovane == 2)
            {
                jeHavarovane = true;
            }
            Car car = new Car(id, rokVyroby, pocetKm, znacka, typAuta, druhPaliva, cena, predajneMiesto, pocetDveri, jeHavarovane);
            cars.Add(car);
            MaxId++;
        }

        public static string WriteCarsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Car car in cars)
            {
                sb.Append(car.Id.ToString() + '\t');
                sb.Append(car.RokVyroby.ToString() + '\t');
                sb.Append(car.PocetKm.ToString() + '\t');
                sb.Append(car.Znacka.ToString() + '\t');
                sb.Append(car.TypAuta.ToString() + '\t');
                sb.Append(car.DruhPaliva.ToString() + '\t');
                sb.Append(car.Cena.ToString() + '\t');
                sb.Append(car.PredajneMiesto.ToString() + '\t');
                sb.Append(car.PocetDveri.ToString() + '\t');
                sb.AppendLine(car.JeHavarovane.ToString());
            }
            return sb.ToString();

        }

        public static void DeleteCar()
        {
            Console.WriteLine("Zadaj id auta, ktore chces vymazat:");
            int selectedId = int.Parse(Console.ReadLine());
            bool lineToDeleteExists = false;
            foreach (Car car in cars)
            {
                if(car.Id == selectedId)
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
            Console.WriteLine("Zadaj id auta, ktore chces zmenit:");
            int selectedId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ktory parameter chces zmenit?");
            Console.WriteLine("1 - rok vyroby");
            Console.WriteLine("2 - pocet najazdenych km");
            Console.WriteLine("3 - znacka");
            Console.WriteLine("4 - typ auta");
            Console.WriteLine("5 - druh paliva: 1 - benzin / 2 - diesel");
            Console.WriteLine("6 - cena");
            Console.WriteLine("7 - mesto, kde sa predava");
            Console.WriteLine("8 - pocet dveri: 3 / 5");
            Console.WriteLine("9 - je havarovane? 1 - nie / 2 - ano");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadaj novu hodnotu:");
            string newValue = Menu.ChangeCarValue(choice);
            foreach (Car car in cars)
            {
                if (car.Id == selectedId)
                {
                    switch (choice)
                    {
                        case 1:
                            car.RokVyroby = int.Parse(newValue);
                            break;
                        case 2:
                            car.PocetKm = int.Parse(newValue);
                            break;
                        case 3:
                            car.Znacka = newValue;
                            break;
                        case 4:
                            car.TypAuta = newValue;
                            break;
                        case 5:
                            int palivo = int.Parse(Console.ReadLine()) - 1;
                            car.DruhPaliva = (Car.Palivo)palivo;
                            break;
                        case 6:
                            car.Cena = int.Parse(newValue);
                            break;
                        case 7:
                            car.PocetDveri = int.Parse(newValue);
                            break;
                        case 8:
                            int havarovane = int.Parse(Console.ReadLine());
                            bool jeHavarovane = false;
                            if (havarovane == 2)
                            {
                                jeHavarovane = true;
                            }
                            car.JeHavarovane = jeHavarovane;
                            break;
                    }                    
                }
            }
        }

        //public static void DeleteCar()
        //{
        //    Console.WriteLine("Zadaj id auta, ktore chces vymazat:");
        //    int selectedId = int.Parse(Console.ReadLine());
        //    OpenFile(fileName);
        //    StringBuilder sb = new StringBuilder();
        //    bool lineToDeleteExists = false;
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        int lineId = ReadId(i);
        //        if (lineId == selectedId)
        //        {
        //            lineToDeleteExists = true;
        //            continue;
        //        }
        //        sb.AppendLine(lines[i]);
        //    }
        //    if (lineToDeleteExists)
        //    {
        //        SaveToFile(sb.ToString());
        //    }
        //    else
        //    {
        //        Console.WriteLine("Neexistuje zaznam s tymto id.");
        //        Console.ReadLine();
        //    }
        //}

        //public static void ChangeCar()
        //{
        //    Console.WriteLine("Zadaj id auta, ktore chces zmenit:");
        //    int selectedId = int.Parse(Console.ReadLine());
        //    OpenFile(fileName);
        //    StringBuilder sb = new StringBuilder();
        //    StringBuilder sb1 = new StringBuilder();
        //    int choice = Menu.ChangeCarOptions();
        //    string newValue = Menu.ChangeCarValue(choice);
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        int lineId = ReadId(i);
        //        if (lineId == selectedId)
        //        {
        //            ReadLine(selectedId - 1);
        //            zaznam[choice] = newValue;
        //            foreach (string value in zaznam)
        //            {
        //                sb1.Append(value + '\t');
        //            }
        //            lines[i] = sb1.ToString();
        //        }
        //        sb.AppendLine(lines[i]);
        //        SaveToFile(sb.ToString());
        //    }
        //}
















    }
}
