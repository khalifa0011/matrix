using matrixTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Iservice
{
    public interface ICategoryService
    {
        int AddCategory(Category category);
         List<Category> GetCategoryList();
         Category GetCategory(int Id);
         int UpdateCategory(Category category);
         int DeleteCategory(Category category); 

    }
}
