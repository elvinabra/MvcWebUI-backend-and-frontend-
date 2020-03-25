using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "You can write  minimum of 2, maximum of 20 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public bool IsHome{ get; set; }

        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}