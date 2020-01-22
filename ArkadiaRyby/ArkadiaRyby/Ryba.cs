using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiaRyby
{
    class Ryba
    {
        public string nazwa, opis, pora, gdzieZlowione, gdzieSprzedane;
        public int cenaKg;
        public double waga;
        public Ryba(string nazwa, string opis, string pora, string gdzieZlowione, string gdzieSprzedane, double waga, int cenaKg )
        {
            this.nazwa = nazwa;
            this.opis = opis;
            this.pora = pora;
            this.gdzieZlowione = gdzieZlowione;
            this.gdzieSprzedane = gdzieSprzedane;
            this.cenaKg = cenaKg;
            this.waga = waga;
        }

        public string OpiszRybe()
        {
            //ladne do wyswietlenia
            string to = "";
            to += nazwa+"--" +opis+ " -- zlowiona w: "+ pora +": <"
                + gdzieZlowione+"> i sprzedane: <" + gdzieSprzedane+"> za " + cenaKg + "/kg";
            to += ". Cala ryba wazyla: " + waga;
            return to;

        }

        public string ZapiszRybe()
        {
            //przygotowane do pliku
            string to = "";
            to += nazwa + ";";
            to += opis + ";";
            to += pora + ";";
            to += gdzieZlowione + ";";
            to += gdzieSprzedane + ";";
            to += (waga * 1000) + ";";
            to += cenaKg;
            return to;
        }

    }
}
