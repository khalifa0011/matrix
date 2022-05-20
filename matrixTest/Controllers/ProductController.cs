using matrixTest.Iservice;
using matrixTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly ICategoryService CategoryService;
        private readonly IPropertyService PropertyService;

        public ProductController(IProductService _ProductService, ICategoryService _CategoryService, IPropertyService _PropertyService)
        {
            ProductService = _ProductService;
            CategoryService = _CategoryService;
            PropertyService = _PropertyService;
        }

        public IActionResult Index(string SearchText = "")
        {
            List<Product> products;
            if (!String.IsNullOrEmpty(SearchText))
            {
                products =  ProductService.GetProductsWithSearch(SearchText);
            }
            else
            {
                products =  ProductService.GetProductList();
            }
            return View(products);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryList = CategoryService.GetCategoryList();
            return View();
        }
        public ActionResult AddProperty(int id)
        {
            ViewBag.categoryId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddProperty(Property model)
        {
            try
            {
                PropertyService.AddProperty(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(AddProperty), new { id = model.CategoryId });
            }
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            try
            {

                ProductService.AddProduct(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.selectedProduct = ProductService.GetProduct(id);
            ViewBag.CategoryList = CategoryService.GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            try
            {
                ProductService.UpdateProduct(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = ProductService.GetProduct(id);
            ProductService.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
