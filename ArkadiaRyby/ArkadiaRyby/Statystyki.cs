using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiaRyby
{
    class Statystyki
    {
        List<Ryba> ryby;
        public Statystyki(List<Ryba> ryby)
        {
            this.ryby = ryby;
        }



        public List<Ryba> PoraRyba(string naz, string por)
        {
            List<Ryba> rybki = new List<Ryba>();
            int n = ryby.Count;
            for (int i = 0; i < n; i++)
                if (ryby[i].nazwa == naz && ryby[i].pora == por) rybki.Add(ryby[i]);

            return rybki;
        }

        public List<Ryba> PorwWagi(double w, int mw) //0 mniejsze i 1 wieksze od w
        {
            List<Ryba> rybki = new List<Ryba>();
            int n = ryby.Count;
            for (int i = 0; i < n; i++)
                switch(mw)
                {
                    case 0:
                        if (ryby[i].waga <= w) rybki.Add(rybki[i]);
                        break;
                    case 1:
                        if (ryby[i].waga >= w) rybki.Add(rybki[i]);
                        break;
                }

            return rybki;
        }

        public double SredniaWagaRyba(string nazw)
        {
            List<Ryba> rybki = new List<Ryba>();
            double sr = 0;
            int n = ryby.Count;
            for (int i = 0; i < n; i++)
            {
                if (ryby[i].nazwa == nazw) rybki.Add(ryby[i]);
            }
            int m = rybki.Count;
            for (int i = 0; i < m; i++) sr += rybki[i].waga;

            sr /= m;
            return sr;
        }

        public double SredniaCenaRyba(string nazw)
        {
            List<Ryba> rybki = new List<Ryba>();
            double sr = 0;
            int n = ryby.Count;
            for (int i = 0; i < n; i++)
            {
                if (ryby[i].nazwa == nazw) rybki.Add(ryby[i]);
            }
            int m = rybki.Count;
            for (int i = 0; i < m; i++) sr += rybki[i].cenaKg;

            sr /= m;
            return sr;
        }

    }
}
