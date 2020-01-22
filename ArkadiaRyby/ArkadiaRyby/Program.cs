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
            List<Ryba> ryby = new List<Ryba>();
            Operating opera = new Operating(ryby);
            Statystyki stats = new Statystyki(ryby);
            zPliku(ryby, opera);


            opera.Menu(ryby);



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
            //    for (int i = 0; i < sTab.Length; i++) Console.Write(sTab[i] + "\\");
              //  Console.WriteLine();
                opera.rybaZPliku(sTab, ryby);
            }
            file.Close();

        }


    }
}
