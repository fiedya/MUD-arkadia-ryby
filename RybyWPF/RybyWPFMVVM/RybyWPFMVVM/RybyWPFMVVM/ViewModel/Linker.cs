using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace RybyWPFMVVM.ViewModel
{
    using Model;
    using BaseClass;
    using System.Windows.Controls.Primitives;
    using System.Windows.Controls;
    internal class Linker:ViewModelBase
    {
        private Operating opera = new Model.Operating();
        public ObservableCollection<Ryba> oc = new ObservableCollection<Ryba>();
        private Czas czas = new Czas();
        public Linker()
        {
            oc = JsonManager.LoadJsonBase();

        }


        #region Pola prywatne i publiczne
        private string nazwa, shortName, przyneta, poraRoku, poraDnia, gdzieZlowione, gdzieSprzedane;
        private int waga, cena;

        public string Nazwa
        {
            get { return nazwa; }
            set
            {
                nazwa = value;
                onPropertyChanged(nameof(Nazwa));
            }
        }

        public string ShortName
        {
            get { return shortName; }
            set
            {
                shortName = value;
                onPropertyChanged(nameof(ShortName));
            }
        }
        public string Przyneta
        {
            get { return przyneta; }
            set
            {
                przyneta = value;
                onPropertyChanged(nameof(Przyneta));
            }
        }
        public string PoraRoku
        {
            get { return poraRoku; }
            set
            {
                poraRoku= value;
                onPropertyChanged(nameof(PoraRoku));
            }
        }
        public string PoraDnia
        {
            get { return poraDnia; }
            set
            {
                poraDnia = value;
                onPropertyChanged(nameof(PoraDnia));
            }
        }
        public string GdzieZlowione
        {
            get { return gdzieZlowione; }
            set
            {
                gdzieZlowione= value;
                onPropertyChanged(nameof(GdzieZlowione));
            }
        }
        public string GdzieSprzedane
        {
            get { return gdzieSprzedane; }
            set
            {
                gdzieSprzedane = value;
                onPropertyChanged(nameof(GdzieSprzedane));
            }
        }
        public int Waga {
            get { return waga; }
            set
            {
                waga = value;
                onPropertyChanged(nameof(Waga));
            }
        }
        public int Cena {
            get { return cena; }
            set
            {
                cena = value;
                onPropertyChanged(nameof(Cena));
            }
        }

        public ObservableCollection<Ryba> Oc
        {
            get { return oc; }
            set
            {
                oc = value;
                onPropertyChanged(nameof(Oc));
            }
        }

        public string[] PoryRoku
        {
            get { return czas.PoryRoku; }
        }

        private Ryba curRyba;
        public Ryba CurRyba
        {
            get { return curRyba; }
            set
            {
                curRyba = value;
                if (curRyba != null)
                {
                    Nazwa = curRyba.Nazwa;
                    ShortName = curRyba.ShortName;
                    Przyneta = curRyba.Przyneta;
                    PoraRoku = curRyba.PoraRoku;
                    PoraDnia = curRyba.PoraDnia;
                    GdzieZlowione = curRyba.GdzieZlowione;
                    GdzieSprzedane = curRyba.GdzieSprzedane;
                    Waga = curRyba.Waga;
                    Cena = curRyba.Cena;
                }
                onPropertyChanged(nameof(CurRyba));

            }
        }

        #endregion

        #region Polecenia


        #endregion
    }
}
