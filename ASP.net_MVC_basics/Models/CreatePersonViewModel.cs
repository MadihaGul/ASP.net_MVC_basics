using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_MVC_basics.Models
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter Person name"),MaxLength(100),MinLength(2)]
        [Display(Name="Person Name")]
        public string Name { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter Phone number"), MaxLength(13), MinLength(9)]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter city"), MaxLength(100), MinLength(2)]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}
