using matrixTest.Iservice;
using matrixTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly MyDbContext context;
        public CategoryService(MyDbContext _context)
        {
            context = _context;
        }

        public  int AddCategory(Category category)
        {
              context.Categories.Add(category);
               context.SaveChanges();
            return category.Id;
        }

        public  int DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
              context.SaveChanges();
            return category.Id;
        }

        public  Category GetCategory(int Id)
        {
            return   context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        }

        public List<Category> GetCategoryList()
        {
            return  context.Categories.ToList();
        }

        public  int UpdateCategory(Category category)
        {
            context.Update(category);
              context.SaveChanges();
            return category.Id;
        }
    }
}
