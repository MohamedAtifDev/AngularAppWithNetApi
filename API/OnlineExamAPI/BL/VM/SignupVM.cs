using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication28.BL.VM
{
    public class SignupVM
    {
        [EmailAddress(ErrorMessage = "Enter valid mail")]
        [Required(ErrorMessage = "Email Required")]
        public string mail { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min length is 5")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("password",ErrorMessage ="please check password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "min length is 5")]
        public string userName { get; set; }
    
    }

}
