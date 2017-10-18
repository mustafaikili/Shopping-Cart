using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.WebMVC.UI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Product { get; set; }
        public int CurrentCategory { get; set; }
    }
}
