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
    public class PropertyController : Controller
    {
        private readonly IPropertyService PropertyService;
        private readonly ICategoryService CategoryService;

        public PropertyController(IPropertyService _PropertyService, ICategoryService _CategoryService)
        {
            this.PropertyService = _PropertyService;
            this.CategoryService = _CategoryService;
        }

        public IActionResult Index()
        {
            var result = PropertyService.GetPropertyList();
            return View(result);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryList = CategoryService.GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Property model)
        {
            try
            {

                PropertyService.AddProperty(model);
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
            ViewBag.selectedProperty = PropertyService.GetProperty(id);
            ViewBag.CategoryList = CategoryService.GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Property model)
        {
            try
            {
                PropertyService.UpdateProperty(model);
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
            var property = PropertyService.GetProperty(id);
            PropertyService.DeleteProperty(property);
            return RedirectToAction(nameof(Index));
        }
    }
}
