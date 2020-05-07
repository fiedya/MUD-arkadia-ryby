using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobyMVVM.Model
{  
    /// <summary>
    /// Klasa Osoby
    /// </summary>
    public class Person
    {
        
        public Person(string surname, string name, int? age, int? weight)
        {
            //pierwsza litera duża, potem małe, a ten cudny if w ramach pustego stringa
            this.Name = name != "" ? Operating.Uplo(name) : "";
            this.Surname = surname != "" ? Operating.Uplo(surname) : "";
            this.Age = age;
            this.Weight = weight;

        }

        public string Name { get ; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }

    }
}
