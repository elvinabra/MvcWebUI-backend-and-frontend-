using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }
      
        
        [StringLength(50, MinimumLength = 2, ErrorMessage = "You can write  minimum of 2, maximum of 20 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}