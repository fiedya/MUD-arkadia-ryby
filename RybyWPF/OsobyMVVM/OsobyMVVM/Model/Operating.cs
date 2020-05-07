using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobyMVVM.Model
{
    /// <summary>
    /// Klasa, która miałą służyć czemuś, ale widzę że niekoniecznie...
    /// </summary>
    class Operating
    {
        public Person person { get; } = new Person("", "", 0,0);

      
        public Person AddPerson(string[] s, int[] i)
        {
            person.Surname = Uplo(s[0]);
            person.Name = Uplo(s[1]);
            person.Age = i[0];
            person.Weight = i[1];

            return person;
        }

        //pierwsza duża litera, reszta mała.
        //static nie wymaga instancji klasy, bo nie chce jej robić w klasie Person (gdzie potrzebuję funkcji)
        public static string Uplo(string s)
        {
            return s.First().ToString().ToUpper() + s.Substring(1).ToLower();
        }


    }
}
