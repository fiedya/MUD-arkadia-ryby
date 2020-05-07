using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace OsobyMVVM.Model
{
    /// <summary>
    /// Klasa służąca konwersji do JSON i z JSONa
    /// </summary>
   static class JsonManager
    {
        static string path = @"../../people.json";
        public static void PersonToJson(Person p)
        {
            string jsonString;
            jsonString = JsonConvert.SerializeObject(p);
            File.AppendAllText(path,jsonString+Environment.NewLine); //dodaje nową linię -> nową osobę

        }

        public static void PeopleToJson(ObservableCollection<Person> oc)
        {
            File.WriteAllText(path, string.Empty);
            string jsonString;
            for(int i=0; i<oc.Count; i++)
            {
                jsonString = JsonConvert.SerializeObject(oc[i]);
                File.AppendAllText(path, jsonString + Environment.NewLine); // dodaje nową linię dla każdej osoby w liście oc
            }
        }

        public static ObservableCollection<Person> LoadJsonBase()
        {
            ObservableCollection<Person> oc = new ObservableCollection<Person>();
            Person p;
            if(File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            p = JsonConvert.DeserializeObject<Person>(line); //zamienia JSONa na ObservableCollection
                            oc.Add(p);
                        }
                    }
                }
            }
            if (oc == null) oc = new ObservableCollection<Person>();
            return oc;
        }
    }
}
