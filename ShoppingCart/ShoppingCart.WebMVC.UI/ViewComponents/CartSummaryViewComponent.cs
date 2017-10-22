using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ShoppingCart.WebMVC.UI.Models;
using ShoppingCart.WebMVC.UI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.WebMVC.UI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly ICartSummaryService _cartSummaryService;
        public CartSummaryViewComponent(ICartSummaryService cartSummaryService)
        {
            _cartSummaryService = cartSummaryService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSummaryService.GetCart()
            };
            return View(model);
        }
    }
}
