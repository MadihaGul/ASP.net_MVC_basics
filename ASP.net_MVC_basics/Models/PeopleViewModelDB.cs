using ASP.net_MVC_basics.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class PeopleViewModelDB : CreatePersonViewModel
    {
        public List<PeopleModel> ListPersonView { get; set; }

        public List<LanguageModel> ListLanguage { get; set; }

        public string FilterString { get; set; }

        public PeopleViewModelDB()
        {
            ListPersonView = new List<PeopleModel>();
        }

        
    }
}
