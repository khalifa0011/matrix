using matrixTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Iservice
{
    public interface IProductService
    {
        int AddProduct(Product product);
        List<Product> GetProductList();
        Product GetProduct(int Id);
        int UpdateProduct(Product product);
        int DeleteProduct(Product product);
        List<Product> GetProductsWithSearch(string SearchText);
        
        }
}
