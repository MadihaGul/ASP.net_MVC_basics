using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Data
{
    public class PeopleModel
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please enter Person name"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Phone number"), MaxLength(13), MinLength(9)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //Navigation properties
        public int CityId { get; set; }
        public virtual CityModel City { get; set; }
    }
}
