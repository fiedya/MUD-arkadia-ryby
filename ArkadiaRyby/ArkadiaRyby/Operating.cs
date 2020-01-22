using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiaRyby
{
    class Operating
    {

        public Operating()
        {

        }

        public void dodajRybe(List<Ryba> ryby)
        {
            Console.WriteLine("WSZYSTKO Z MALYCH LITER");
            Ryba ryba = new Ryba("", "", "", "", "", 0, 0);
            char[] whitespace = new char[] { ' ', '\t' };

            Console.Write("Podaj nazwe ryby i po spacji jej shorta: ");
            string ryb = Console.ReadLine();
            string[] nazw = ryb.Split(whitespace);
            ryba.nazwa = nazw[0];
            ryba.opis = nazw[1];
            bool x = false;
            string s = "???";
            while (x != true)
            {
                Console.Write("Podaj pore roku (z malej litery) : ");
                s = Console.ReadLine();
                if (s == "lato" || s == "wiosna" || s == "zima" || s == "jesien") x = true;
            }
            ryba.pora = s;

            Console.Write("Gdzie zlowione? : ");
            ryba.gdzieZlowione = Console.ReadLine();
            Console.Write("Gdzie sprzedane? : ");
            ryba.gdzieSprzedane = Console.ReadLine();
            Console.WriteLine("Za ile? Zloto, srebro i miedz oddzielone spacjami: ");
            string cen = Console.ReadLine();
            string[] ceny = cen.Split(whitespace);
            Console.Write("Waga w kg: ");
            double w = Convert.ToDouble(Console.ReadLine());
            ryba.waga = w;
            ryba.cenaKg = NaMiedz(ceny[0], ceny[1], ceny[2], w);

            ryby.Add(ryba);
        }

        public int NaMiedz(string z, string s, string m, double waga)
        {
            int zi = Convert.ToInt16(z);
            int si = Convert.ToInt16(s);
            int mi = Convert.ToInt16(m);
            return (int)Math.Floor(Convert.ToDecimal((zi*20*12 + si*12 +mi)/waga));
        }

        public void rybaZPliku(string[] sTab, List<Ryba> ryby)
        {
            Ryba ryba = new Ryba(sTab[0], sTab[1], sTab[2], sTab[3], sTab[4], Convert.ToDouble(sTab[5])/1000, Convert.ToInt16(sTab[6]));
            ryby.Add(ryba);

        }

        public void WyswietlWszystkie(List<Ryba> ryby)
        {
            for (int i = 0; i < ryby.Count; i++) Console.WriteLine(ryby[i].OpiszRybe());
        }
    }
}
