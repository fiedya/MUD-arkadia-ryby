using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace RybyWPFMVVM.ViewModel
{
    using Model;
    using BaseClass;
    using System.Windows.Controls.Primitives;
    using System.Windows.Controls;
    static class JsonManager
    {



        static string path = @"../../ryby.json";
        static string pathtxt = @"../../ListaRyb.txt";
        public static void RybaDoJsona(Ryba r)
        {
            string jsonString;
            jsonString = JsonConvert.SerializeObject(r);
            File.AppendAllText(path, jsonString + Environment.NewLine); //dodaje nową linię -> nową osobę

        }

        public static void PeopleToJson(ObservableCollection<Ryba> oc)
        {
            File.WriteAllText(path, string.Empty);
            string jsonString;
            for (int i = 0; i < oc.Count; i++)
            {
                jsonString = JsonConvert.SerializeObject(oc[i]);
                File.AppendAllText(path, jsonString + Environment.NewLine); // dodaje nową linię dla każdej osoby w liście oc
            }
        }

        public static ObservableCollection<Ryba> LoadJsonBase()
        {
            ObservableCollection<Ryba> oc = new ObservableCollection<Ryba>();
            Ryba r;
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            r = JsonConvert.DeserializeObject<Ryba>(line); //zamienia JSONa na ObservableCollection
                            oc.Add(r);
                        }
                    }
                }
            }
            if (oc == null) oc = new ObservableCollection<Ryba>();
            return oc;
        }


        public static void TxtToJSON()
        {
            ObservableCollection<Ryba> oc = new ObservableCollection<Ryba>();
            if (File.Exists(pathtxt))
            {
                using (var reader = new StreamReader(pathtxt))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] s = line.Split(';');
                            Ryba r = new Ryba("", "", "", "", "", "", "", 0, 0);
                            r.Nazwa = s[0];
                            r.ShortName = s[1];
                            r.Przyneta = s[2];
                            r.PoraRoku = s[3];
                            r.PoraDnia = s[4];
                            r.GdzieZlowione = s[5];
                            r.GdzieSprzedane = s[6];
                            r.Waga = Convert.ToInt32(s[7]);
                            r.Cena = Convert.ToInt32(s[8]);
                            oc.Add(r);
                        }
                    }
                }
            }

            PeopleToJson(oc);


        }

    }
}
