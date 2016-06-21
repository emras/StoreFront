using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store_Front.Models
{
    public class RegistrationViewModel:LoginViewModel
    {


        [Required(ErrorMessage = "Please enter email address.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email Address is Invalid")]
        public string EmailAddress { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }


    }
}