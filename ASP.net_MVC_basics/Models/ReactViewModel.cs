using ASP.net_MVC_basics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class ReactViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string SpeakLanguages { get; set; }
    }
}
