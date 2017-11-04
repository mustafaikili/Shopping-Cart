using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.WebMVC.UI.Models;
using ShoppingCart.Business.Abstract;
using ShoppingCart.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingCart.WebMVC.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            int productId = 0;
            var productListViewModel = new ProductListViewModel
            {
                Product = _productService.GetList(productId).ToList()
            };
            return View(productListViewModel);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Ürününüz başarıyla eklenmiştir.");
            }
            return RedirectToAction("Add");
        }
        [HttpGet]
        public ActionResult Update(int productId)
        {
            var model = new productUpdateViewModel
            {
                Product = _productService.Get(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Ürününüz başarıyla güncellenmiştir.");
            }
            return RedirectToAction("Update");
        }
        public ActionResult Delete(int productId)
        {
            _productService.Delete(_productService.Get(productId));
            TempData.Add("mesage", "Ürününüz başarıyla silinmiştir.");
            return RedirectToAction("Index");
        }
    }
}