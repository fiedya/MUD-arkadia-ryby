using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiaRyby
{
    class Ryba
    {
        public string nazwa, opis, przyneta, pora, gdzieZlowione, gdzieSprzedane, czas;
        public int cenaKg;
        public double waga;
        public Ryba(string nazwa, string opis, string przyneta, string pora, string czas, string gdzieZlowione, string gdzieSprzedane, double waga, int cenaKg )
        {
            this.nazwa = nazwa;
            this.opis = opis;
            this.pora = pora;
            this.czas = czas;
            this.przyneta = przyneta;
            this.gdzieZlowione = gdzieZlowione;
            this.gdzieSprzedane = gdzieSprzedane;
            this.cenaKg = cenaKg;
            this.waga = waga;
        }

        public string OpiszRybe()
        {
            //ladne do wyswietlenia
            string to = "";
            to += nazwa + " -- " + opis + " -- zlowiona w: " + pora + "/"+czas+" : <"
                + gdzieZlowione + " na "+przyneta+"> i sprzedane: <" + gdzieSprzedane + "> za " + cenaKg + "/kg";
            to += ". Wazyla: " + waga;
            return to;

        }

        public string ZapiszRybe()
        {
            //przygotowane do pliku
            string to = "";
            to += nazwa + ";";
            to += opis + ";";
            to += przyneta + ";";
            to += pora + ";";
            to += czas + ";";
            to += gdzieZlowione + ";";
            to += gdzieSprzedane + ";";
            to += (waga * 1000) + ";";
            to += cenaKg;
            return to;
        }

    }
}
