using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Data
{
    public class PeopleLanguageModel
    {
        public int PersonId { get; set; }
        public  PeopleModel Person{ get; set; }
        public int LanguageId { get; set; }
        public  LanguageModel Language { get; set; }
    }
}
