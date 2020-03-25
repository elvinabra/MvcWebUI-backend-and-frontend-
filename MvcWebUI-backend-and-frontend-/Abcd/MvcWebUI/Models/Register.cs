using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class Register
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "The email address you included is not correct")]
        public string Email { get; set; }
        [Required]
        
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Your passwords do not match")]
        public string Repassword { get; set; }
    }
}