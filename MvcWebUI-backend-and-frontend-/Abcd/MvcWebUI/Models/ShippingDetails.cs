using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class ShippingDetails
    {

      
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter the address title")]
        public string AdressTitle { get; set; }
        [Required(ErrorMessage = "Please enter the address")]
        public string Adress{ get; set; }
        [Required(ErrorMessage = " Please enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = " Please enter your district")]
        public string District { get; set; }
        public string ZipCode { get; set; }
    }
}