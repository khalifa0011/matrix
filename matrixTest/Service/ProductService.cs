using matrixTest.Iservice;
using matrixTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Service
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext context;
        public ProductService(MyDbContext _context)
        {
            context = _context;
        }

        public int AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }

        public int DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return product.Id;
        }

        public Product GetProduct(int Id)
        {
            return context.Products.Where(c => c.Id == Id).FirstOrDefault();
        }

        public List<Product> GetProductList()
        {
            return context.Products.Include(x => x.Category).ToList();
        }

        public int UpdateProduct(Product product)
        {
            context.Update(product);
            context.SaveChanges();
            return product.Id;
        }
        public  List<Product> GetProductsWithSearch(string SearchText)
        {
            return  context.Products.Include(x => x.Category).Where(
                c => c.Name.Contains(SearchText)||
            c.Category.Name.Contains(SearchText)||
            c.Name.Contains(SearchText)).ToList();
        }
    }
}
