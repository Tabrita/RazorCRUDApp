using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using RazorCRUDApp.Data;
using RazorCRUDApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCRUDApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RazorCRUDContext _context;

        public ProductRepository(RazorCRUDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(c => c.Category)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            return await _context.Products.Include(p => p.Category)
                            .Where(p => string.IsNullOrEmpty(name) ||
                            p.Name.ToLower().Contains(name.ToLower()))
                            .OrderBy(p => p.Name)
                            .ToListAsync();
        }      

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
        {
            return await _context.Products
                        .Where(c => c.CategoryId == categoryId)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified; 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product); 
            await _context.SaveChangesAsync();
        }
    }
}
