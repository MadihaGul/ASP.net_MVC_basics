using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class Person
    {
        private readonly int _personId;
        public int PersonId { get{ return _personId; } }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        public Person(int id, string name, string phone, string city)
        {
            this._personId = id;
            Name = name;
            Phone = phone;
            City = city;
        
        }
                
    }
}
