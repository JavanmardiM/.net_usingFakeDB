using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace usingFakeDB.Pages
{
    public class CreateModel : PageModel
    {
        private readonly myAppDBContext _db;
        private ILogger<CreateModel> Log;
        public CreateModel(myAppDBContext db, ILogger<CreateModel> log)
        {
            _db = db;
            Log = log;
        }

        [TempData]
        public string Massage { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            var msg = $" customer {Customer.Name} added :)";
            Massage = msg;
            Log.LogCritical(msg);
            return RedirectToPage("/Index");
        }
    }
}