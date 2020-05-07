using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RybyWPFMVVM.Model
{
    class Ryba
    {
        public Ryba()
        {

        }

        public Ryba(string nazwa, string shortName, string przyneta, string poraRoku, string PoraDnia,
           string gdzieZlowione, string gdzieSprzedane, int waga, int cena) //cena za kg
        {

        }


        public string Nazwa { get; set; }
        public string ShortName { get; set; }
        public string Przyneta{ get; set; }
        public string PoraRoku { get; set; }
        public string PoraDnia { get; set; }
        public string GdzieZlowione { get; set; }
        public string GdzieSprzedane { get; set; }
        public int Waga { get; set; }
        public int Cena { get; set; }


    }
}
