using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndentityRobotna.Models.ViewModels
{
    public class RegestirViewModel
    {
          [EmailAddress]
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Confirm Password ")]
        [Compare("Password",ErrorMessage = "Password and Confirm not match")]
        public string ConfirmPassword { get; set; }
        public string Mobile { get; set; }


    }
}
