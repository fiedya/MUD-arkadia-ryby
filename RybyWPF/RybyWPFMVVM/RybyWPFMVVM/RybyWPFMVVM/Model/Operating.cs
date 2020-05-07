using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RybyWPFMVVM.Model
{
    class Operating
    {
        public Operating()
        {

        }

        public Ryba r { get; } = new Ryba("", "","","","","","", 0, 0);


        public Ryba AddPerson(string[] s, int[] i)
        {
            r.Nazwa = Uplo(s[0]);
            r.ShortName = Uplo(s[1]);
            r.Przyneta = Uplo(s[2]);
            r.PoraRoku = Uplo(s[3]);
            r.PoraDnia = Uplo(s[4]);
            r.GdzieZlowione = Uplo(s[5]);
            r.GdzieSprzedane = Uplo(s[6]);
            r.Waga = i[0];
            r.Cena = i[1];

            return r;
        }


        public static string Uplo(string s)
        {
            return s.First().ToString().ToUpper() + s.Substring(1).ToLower();
        }
    }
}
