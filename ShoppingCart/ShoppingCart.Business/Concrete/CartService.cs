using ShoppingCart.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Entities.Concrete;
using System.Linq;

namespace ShoppingCart.Business.Concrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId);
            if (cartLine.Quantity == 1)
            {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId));
            }
            else
            {
                cartLine.Quantity--;
            }
        }
    }
}
