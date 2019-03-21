using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZADANIE1
{
    class Car
    {
        public int Id { get; }                          //0
        public int ManufactureYear { get; set; }        //1
        public int Km { get; set; }                     //2
        public string Brand { get; set; }               //3
        public string Type { get; set; }                //4
        public Fuel FuelType { get; set; }              //5
        public decimal Price { get; set; }                //6
        public string CityOfSale { get; set; }      //7
        public int DoorCount { get; set; }             //8
        public bool IsCrashed { get; set; }          //9

        public enum Fuel
        {           
            benzin,
            diesel,
            hybrid,
            plyn,
            elektro
        }

        
        public Car(int id, int manufactureYear, int km, string brand, string type, Fuel fuel, decimal price, string cityOfSale, int doorCount, bool isCrashed)
        {
            Id = id;
            ManufactureYear = manufactureYear;
            Km = km;
            Brand = brand;
            Type = type;
            FuelType = fuel;
            Price = price;
            CityOfSale = cityOfSale;
            DoorCount = doorCount;
            IsCrashed = isCrashed;
        }


        


    }
}
