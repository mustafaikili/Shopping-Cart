using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.WebMVC.UI.Models;
using ShoppingCart.Business.Abstract;
using ShoppingCart.Entities.Concrete;

namespace ShoppingCart.WebMVC.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int category = 0)
        {
            var products = _productService.GetList(category);
            ProductListViewModel model = new ProductListViewModel {
                Product = products.ToList(),
                 CurrentCategory = category
            };
            return View(model);
        }
    }
}