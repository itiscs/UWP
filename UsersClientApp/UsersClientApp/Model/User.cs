using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersClientApp.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string[] Interests { get; set; }
    }
}
