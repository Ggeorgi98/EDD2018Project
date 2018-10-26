using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUDRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext dbContext;
        public ICollection<Customer> Customers { get; set; }

        public IndexModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGetAsync()
        {
            Customers = dbContext.Customers.AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            if(customer != null)
            {
                dbContext.Remove(customer);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
