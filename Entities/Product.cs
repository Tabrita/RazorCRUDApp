using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCRUDApp.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public string Summary { get; set; }

        
        public string Description { get; set; }

        public string ImageFile { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
