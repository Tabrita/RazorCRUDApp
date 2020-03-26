using RazorCRUDApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCRUDApp.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductListAsync(); 
        Task<Product> GetProductByIdAsync(int id); 
        Task<IEnumerable<Product>> GetProductByNameAsync(string name); 
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId); 
        Task<Product> AddAsync(Product product); 
        Task UpdateAsync(Product product); 
        Task DeleteAsync(Product product); 
        Task<IEnumerable<Category>> GetCategories();
    }
}
