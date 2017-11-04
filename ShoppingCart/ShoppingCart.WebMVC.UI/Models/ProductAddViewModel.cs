using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.WebMVC.UI.Models
{
    public class ProductAddViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
