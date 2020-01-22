using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArkadiaRyby
{
    class Program
    {
        static void Main(string[] args)
        {
            Operating opera = new Operating();
            List<Ryba> ryby = new List<Ryba>();
            Statystyki stats = new Statystyki(ryby);
            zPliku(ryby, opera);
            //Console.WriteLine(ryby.Count);
            //for (int i = 0; i < 54; i++)
            //{
            //    opera.dodajRybe(ryby);


            //    Console.WriteLine(ryby[0].OpiszRybe());
            //   DoPliku(ryby);
            // }
            double sr = stats.SredniaWagaRyba("belona");
            Console.WriteLine(sr);
           // opera.WyswietlWszystkie(ryby);
            Console.ReadKey();
        }


        public static void DoPliku(List<Ryba> ryby)
        {

            using (StreamWriter sw = new StreamWriter(@"D:\ArkadiaRyby\ArkadiaRyby\ListaRyb.txt"))
            {
 
                for (int v = 0; v < ryby.Count; v++)
                {
                    sw.WriteLine(ryby[v].ZapiszRybe());
                }
            }
        }

        public void pojDoPliku(Ryba ryba)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\ArkadiaRyby\ArkadiaRyby\ListaRyb.txt"))
            {
                sw.WriteLine(ryba.ZapiszRybe());
            }
        }

        public static void zPliku(List<Ryba> ryby, Operating opera)
        {


            StreamReader file =    new System.IO.StreamReader(@"D:\ArkadiaRyby\ArkadiaRyby\ListaRyb.txt");
            
            char[] przecinek = new char[] { ';' };
            string line;
            while ((line = file.ReadLine()) != null)
            {
               string[] sTab = line.Split(przecinek);
                opera.rybaZPliku(sTab, ryby);
            }
            file.Close();

        }


    }
}
