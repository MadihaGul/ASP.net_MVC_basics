using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class PeopleViewModel:CreatePersonViewModel
    {
        public List<Person> ListPersonView { get; set; }
        public string FilterString  {get; set;  }

        public PeopleViewModel()
        {
            ListPersonView = new List<Person>();
        }
    }
}
