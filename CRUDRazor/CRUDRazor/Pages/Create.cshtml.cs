using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDRazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext dbContext;

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)            
                return Page();

            dbContext.Customers.Add(Customer);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}