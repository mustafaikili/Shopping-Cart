using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Business.Abstract;
using ShoppingCart.WebMVC.UI.Services.Abstract;
using ShoppingCart.WebMVC.UI.Models;
using ShoppingCart.Entities.Concrete;

namespace ShoppingCart.WebMVC.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartSummaryService _cartSummaryService;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        public CartController(ICartSummaryService cartSummaryService, IProductService productService, ICartService cartService)
        {
            _cartSummaryService = cartSummaryService;
            _productService = productService;
            _cartService = cartService;
        }
        public ActionResult AddToCart(int productId)
        {
            var product = _productService.Get(productId);
            var cart = _cartSummaryService.GetCart();
            _cartService.AddToCart(cart, product);
            _cartSummaryService.SetCart(cart);

            TempData.Add("message", String.Format("{0} isimli ürününüz başarıyla eklenmiştir.", product.ProductName));
            return RedirectToAction("Index", "Product");
        }
        public ActionResult List()
        {
            var cart = _cartSummaryService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }
        public ActionResult Remove(int productId)
        {
            var product = _productService.Get(productId);
            var cart = _cartSummaryService.GetCart();

            _cartService.RemoveFromCart(cart, product.ProductId);
            _cartSummaryService.SetCart(cart);
            TempData.Add("message", String.Format("{0} isimli ürününüz başarıyla silinmiştir.", product.ProductName));
            return Redirect("List");
        }
        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public ActionResult Complete(ShippingDetailsViewModel shippingDetail)
        {
            if (!ModelState.IsValid)
                return View();
            TempData.Add("message", String.Format("Siparişiniz başarıyla gerçekleştirilmiştir."));
            return View();

        }
    }
}