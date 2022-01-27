using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter first name"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Text)]
        public string FirstName {get; set;}

        [Required(ErrorMessage = "Please enter last name"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter date of birth"), MaxLength(100), MinLength(2)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
