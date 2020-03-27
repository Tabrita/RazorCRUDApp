using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDApp.Repository;

namespace RazorCRUDApp.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DetailsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public Entities.Product product { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int productId)
        {
            
            if (productId == 0)
            {
                return RedirectToPage("./Index");
            }
            product = await _productRepository.GetProductByIdAsync(productId);
            return Page();
        }
    }
}