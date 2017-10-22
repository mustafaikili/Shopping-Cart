using ShoppingCart.WebMVC.UI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using ShoppingCart.WebMVC.UI.ExtensionMethods;

namespace ShoppingCart.WebMVC.UI.Services.Concrete
{
    public class CartSummaryService : ICartSummaryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartSummaryService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck ==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart",cart);
        }
    }
}
