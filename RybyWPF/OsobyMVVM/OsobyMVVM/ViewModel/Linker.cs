using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace OsobyMVVM.ViewModel
{
    using Model;
    using BaseClass;
    using System.Windows.Controls.Primitives;
    using System.Windows.Controls;

    internal class Linker : ViewModelBase
    {
        private Operating opera = new Model.Operating();
        public ObservableCollection<Person> oc = new ObservableCollection<Person>();

        public Linker()
        {
            oc = JsonManager.LoadJsonBase();
        }


        #region Pola prywatne i publiczne

        private string surname;
        private string name;
        private int age;
        private int weight;
            

        public string Surname { 
            get { return surname; } 
            set { surname = value; 
                onPropertyChanged(nameof(surname)); 
            } 
        }
        public string Name { 
            get { return name; } 
            set { name = value; 
                onPropertyChanged(nameof(Name)); 
            } 
        }
        public int Age
        {
            get { return age; }
            set {   age = value;
                onPropertyChanged(nameof(Age));
            }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value;
                onPropertyChanged(nameof(Weight));
            }
        }



        public ObservableCollection<Person> Oc
        {
            get { return oc; }
            set { oc = value;
                onPropertyChanged(nameof(Oc));
            }
        }

        private Person currentPerson;
        public Person CurrentPerson
        {
            get { return currentPerson; }
            set {
                currentPerson = value;
                if (currentPerson != null)
                {
                    Surname = currentPerson.Surname;
                    Name = currentPerson.Name;
                    Age = Convert.ToInt32(currentPerson.Age);
                    Weight = Convert.ToInt32(currentPerson.Weight);
                }
                onPropertyChanged(nameof(CurrentPerson));
               
            }
        }
        #endregion

        #region Polecenia

        // Wywoływane dla przycisku "dodaj osobe"
        private ICommand _returnsList = null;
        public ICommand ReturnsList
        {
            get
            {
                if (_returnsList == null)
                {

                    _returnsList = new RelayCommand(
                       arg =>
                       {
                           if (Age == 0 || Weight == 0 || Name == null || Surname == null || Surname=="" || Name=="")
                               MessageBox.Show("Uwaga! Masz niepoprawne dane!", "UWAGA, BŁĄD");
                           else
                           {
                               Person p = AddPerson(new string[] { Surname, Name }, new int[] { Age, Weight });
                               JsonManager.PersonToJson(p);
                               //dla zapewnienia ze dane beda nowe -> dla zer wywołuje messegeboxa.
                               Age = 0;
                               Weight = 0;
                           }
                       },
                       arg => (true)
                        );
                }
                return _returnsList;
            }
        }


        //wywoływanie dla przycisku "edytuj/aktualizuj"
        private ICommand _editing = null;
        public ICommand Editing
        {
            get
            {
                _editing = new RelayCommand(
                  arg =>
                    {
                        if (currentPerson != null)
                        {
                            if (Age == 0 || Weight == 0 || Name == null || Surname == null || Surname == "" || Name == "")
                                MessageBox.Show("Uwaga! Masz niepoprawne dane!", "UWAGA, BŁĄD");
                            else
                            {

                                EditExisting(currentPerson);
                                JsonManager.PeopleToJson(oc);
                            }
                         }
                       },
                     arg => (true)
                  );
                return _editing;
            }

        }


        //wywoływane dla przycisku "usuń"
        private ICommand _deleting = null;
        public ICommand Deleting
        {
            get
            {
                _deleting = new RelayCommand(
                  arg =>
                  {
                      if(currentPerson!=null)
                      Delete(currentPerson);
                      JsonManager.PeopleToJson(oc);
                  },
                     arg => (true)
                  );
                return _deleting;
            }
        }


        #endregion


        #region Funkcje

        public void Delete(Person p)
        {
            oc.Remove(p);
            JsonManager.PeopleToJson(oc);
            currentPerson = null;
        }

        public void EditExisting(Person current)
        {
            int i = oc.IndexOf(current);
            Oc.Remove(current);
            Person p = opera.AddPerson(new string[] { Surname, Name }, new int[] { Age, Weight });
            Oc.Insert(i, p);
            currentPerson = null;
        }

        public Person AddPerson(string[] s, int[] i)
        {
            s[0] = Operating.Uplo(s[0]);
            s[1] = Operating.Uplo(s[1]);
            Person p = opera.AddPerson(s, i);
            oc.Add(p);
            return p;
        }

        #endregion
    }
}
