using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Data
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please enter country name"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Text)]
        public string CountryName { get; set; }

        //Navigation propeterty
        public virtual List<CityModel> listCity { get; set; }
    }
}
