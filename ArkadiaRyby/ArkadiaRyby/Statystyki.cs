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

        public double SredniaWaga(List<Ryba> rybki)
        {
            double sr = 0;

            int m = rybki.Count;
            for (int i = 0; i < m; i++) sr += rybki[i].waga;

            sr /= m;
            return sr;
        }

        public double SredniaCena(List<Ryba> rybki)
        {

            double sr = 0;
            int m = rybki.Count;
            int counter = 0;
            for (int i = 0; i < m; i++)
            {
                if (rybki[i].cenaKg == 0) counter++;
                sr += rybki[i].cenaKg;

            }
            sr /= (m-counter);
            return sr;
        }

        public List<Ryba> FiltrujStringi(List<Ryba> rybki, string nazwa,
            string opis, string pora, string gdzieZlowione, string gdzieSprzedane)
        {
            List<Ryba> lista = new List<Ryba>();


            foreach (Ryba r in rybki)
            {
                if (nazwa == "" || r.nazwa == nazwa)
                {
                    if (opis == "" || r.opis == opis)
                    {
                        if (pora == "" || r.pora == pora)
                        {
                            if (gdzieZlowione == "" || r.gdzieZlowione == gdzieZlowione)
                            {
                                if (gdzieSprzedane == "" || r.gdzieSprzedane == gdzieSprzedane)
                                {
                                    lista.Add(r);
                                }
                                else break;
                            }
                            else break;
                        }
                        else break;
                    }
                    else break;
                }
                else break;
            }

            return lista;

        }

    }
}
