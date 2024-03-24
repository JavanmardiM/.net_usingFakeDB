using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace usingFakeDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly myAppDBContext _db;
        public IndexModel(myAppDBContext db)
        {
            _db = db;
        }

        [TempData]
        public string Massage { get; set; }
        public IList<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if(customer != null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
