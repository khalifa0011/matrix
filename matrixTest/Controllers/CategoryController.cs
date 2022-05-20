using matrixTest.Iservice;
using matrixTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService )
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var result = categoryService.GetCategoryList();
            return View(result);
        }
        public ActionResult Create()
        {
            ViewBag.categoryList= categoryService.GetCategoryList();
            return View();
        }
        [HttpPost] 
        public  IActionResult Create(Category model)
        {
            try
            {
                 
                  categoryService.AddCategory(model);
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
            ViewBag.selectedcategory = categoryService.GetCategory(id);
            ViewBag.categoryList = categoryService.GetCategoryList();
            return View();
        }
        [HttpPost] 
        public IActionResult Edit(Category model)
        {
            try
            { 
                 categoryService.UpdateCategory(model);
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
            var catg =   categoryService.GetCategory(id);
              categoryService.DeleteCategory(catg);
            return RedirectToAction(nameof(Index));
        }
    }
}
