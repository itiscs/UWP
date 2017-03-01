using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindingApp.Models
{
    public class Person: INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonID { get; set; }

        public Person()
        {
            PersonID = 1;
            FirstName = "John";
            LastName = "Smith";
        }


        public static Person CreatePerson(int id)
        {
            return new Person() { PersonID = id, FirstName = "John", LastName = $"Smith_{id}" };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

    }
}
