using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Data
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please enter city name"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Text)]
        public string CityName { get; set; }

        //Navigation propeterty
        public virtual List<PeopleModel> listPeople { get; set; }
        public int CountryId { get; set; }
        public virtual CountryModel Country { get; set; }
    }
}
