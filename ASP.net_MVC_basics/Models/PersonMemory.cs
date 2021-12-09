using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class PersonMemory
    {
        private static List<Person> _listPerson = new List<Person>();
        private static int _idCounter;

        public void SeedPerson()
        {
            PersonMemory personMemory = new PersonMemory();

            personMemory.CreatePerson("Anna","+46718899111","Stockholm");
            personMemory.CreatePerson("John","+46718899222", "Malmö");
            personMemory.CreatePerson( "Annika", "+46718899333","Partille");
            personMemory.CreatePerson("Monika", "+46718899444", "Göteborg");
            personMemory.CreatePerson("Silvia", "+46715555555" ,"Stockholm");
            personMemory.CreatePerson("Maryam", "+46718899666", "Göteborg");
            personMemory.CreatePerson("Tomas", "+46718899777", "Malmö");
        }

        public Person CreatePerson(string name, string phone, string city)
        {
            Person newPerson = new Person(_idCounter,name,phone,city);
            _listPerson.Add(newPerson);
            _idCounter++;
            return newPerson;
        }

        public bool DeletePerson(Person person)
        {
            bool status = _listPerson.Remove(person);
            return status;
        
        }

        public List<Person> ReadPerson()
        {
            return _listPerson;
        }

        public Person ReadPerson( int id)
        {
            Person targetPerson = _listPerson.Find(p => p.PersonId == id);
            return targetPerson;
        }

    }
}
