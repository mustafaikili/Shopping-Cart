using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart,Product product);
        void RemoveFromCart(Cart cart,int productId);
    }
}
