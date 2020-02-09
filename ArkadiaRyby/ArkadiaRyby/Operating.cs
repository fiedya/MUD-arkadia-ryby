using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiaRyby
{
    class Operating
    {

       
        List<Ryba> ryby;
        public Operating(List<Ryba> ryby)
        {
            this.ryby = ryby;
        }

        public void dodajRybe(List<Ryba> ryby)
        {
            Console.WriteLine("WSZYSTKO Z MALYCH LITER");
            Ryba ryba = new Ryba("", "","", "","", "", "", 0, 0);
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
                if (s.Contains("lato") || s.Contains("wiosna") || s.Contains("jesien") || s.Contains("zima")) x = true;
            }
            ryba.pora = s;
            Console.Write("Jaka pora dnia? ");
            ryba.czas = Console.ReadLine();
            Console.Write("Na co lowione? ");
            ryba.przyneta = Console.ReadLine();
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
            Ryba ryba = new Ryba(sTab[0], sTab[1], sTab[2], sTab[3], sTab[4],sTab[5],sTab[6], Convert.ToDouble(sTab[5])/1000, Convert.ToInt16(sTab[6]));
            ryby.Add(ryba);

        }

        public void WyswietlWszystkie(List<Ryba> ryby)
        {
            for (int i = 0; i < ryby.Count; i++) Console.WriteLine(ryby[i].OpiszRybe());
        }

        public void Menu(List<Ryba> ryby)
        {
            Console.WriteLine("1. Filtruj.");
            Console.WriteLine("2. Srednia cena przefiltrowanych.");
            Console.WriteLine("3. Srednia waga przefiltrowanych.");
            Console.WriteLine("4. Wyswietl przefiltrowane.");
            Console.WriteLine("5. Dodaj rybe.");
            Console.WriteLine("e. Wyjscie.");
            List<Ryba> noweR = ryby;
            Statystyki stats = new Statystyki(noweR);

            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5"&& choice != "e")
            {
                choice = Console.ReadLine();
            }

            switch(choice)
            {
                case "1":
                    Console.WriteLine("Od enterów po kolei: nazwa, opis, przyneta, pora, czas,gdzie zlowione i gdzie sprzedane.");
                    string n = Console.ReadLine();
                    string op = Console.ReadLine();
                    string prz = Console.ReadLine();
                    string por = Console.ReadLine();
                    string cz = Console.ReadLine();
                    string zl = Console.ReadLine();
                    string sp = Console.ReadLine();
                    noweR = stats.FiltrujStringi(ryby, n,op, prz,por,cz,zl,sp);
                    Menu(noweR);
                    break;
                case "2":
                    Console.WriteLine(stats.SredniaCena(noweR));
                    Menu(noweR);
                    break;
                case "3":
                    Console.WriteLine(stats.SredniaWaga(noweR));
                    Menu(noweR);
                    break;
                case "4":
                    WyswietlWszystkie(noweR);
                    Menu(noweR);
                    break;
                case "5":
                    dodajRybe(ryby);
                    Menu(noweR);
                    break;
                case "e":
                    Environment.Exit(0);

                    break;

            }
             
        }
    }
}
