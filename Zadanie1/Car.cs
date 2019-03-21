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
        public int RokVyroby { get; set; }              //1
        public int PocetKm { get; set; }                //2
        public string Znacka { get; set; }              //3
        public string TypAuta { get; set; }             //4
        public Palivo DruhPaliva { get; set; }          //5
        public double Cena { get; set; }                //6
        public string PredajneMiesto { get; set; }      //7
        public int PocetDveri { get; set; }             //8
        public bool JeHavarovane { get; set; }          //9

        public enum Palivo
        {           
            benzin,
            diesel
        }

        
        public Car(int id, int rokVyroby, int pocetKm, string znacka, string typAuta, Palivo druhPaliva, double cena, string predajneMiesto, int pocetDveri, bool jeHavarovane)
        {
            Id = id;
            RokVyroby = rokVyroby;
            PocetKm = pocetKm;
            Znacka = znacka;
            TypAuta = typAuta;
            DruhPaliva = druhPaliva;
            Cena = cena;
            PredajneMiesto = predajneMiesto;
            PocetDveri = pocetDveri;
            JeHavarovane = jeHavarovane;
        }


        


    }
}
