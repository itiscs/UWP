using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App22.Models
{
    public class Person:INotifyPropertyChanged
    {
        private int _personID;
        public int PersonID
        {
            get { return _personID; }
            set { Set(ref _personID, value); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { Set(ref _firstName,value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { Set(ref _lastName, value); }
        }

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
