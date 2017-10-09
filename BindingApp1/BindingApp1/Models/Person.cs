using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingApp1
{
    public class Person:INotifyPropertyChanged
    {
        private int _age;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age {
            get { return _age;}
            set
            {
                _age = value;
                if(PropertyChanged!=null)
                {
                    
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                }
            } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
