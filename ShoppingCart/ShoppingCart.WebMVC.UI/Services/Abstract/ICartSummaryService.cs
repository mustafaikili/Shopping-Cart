using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.WebMVC.UI.Services.Abstract
{
   public interface ICartSummaryService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
