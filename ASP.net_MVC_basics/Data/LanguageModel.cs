using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Data
{
    public class LanguageModel
    {
        [Key]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Please enter Language name"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Text)]
        public string LanguageName { get; set; }


        //Navigation propeterty
        
        public List<PeopleLanguageModel> SpokenByPeople { get; set; }
    }
}
