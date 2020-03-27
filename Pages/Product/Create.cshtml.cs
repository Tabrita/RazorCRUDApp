using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCRUDApp.Entities;
using RazorCRUDApp.Repository;

namespace RazorCRUDApp.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public CreateModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [BindProperty]
        public Entities.Product myProduct { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var categories = await _productRepository.GetCategories();
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var categories = await _productRepository.GetCategories();
            if (!ModelState.IsValid)
            {                
                ViewData["Categories"] = new SelectList(categories, "Id", "Name");
                return Page();
            }                     

            await _productRepository.AddAsync(myProduct);

            return Redirect("./Index");
        }
    }
}