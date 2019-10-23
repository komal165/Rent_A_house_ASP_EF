using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Tenants
{

    //Deletes the tenant.
    public class DeleteModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DeleteModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Binds the tenant to model.
        [BindProperty]
        public Tenant Tenant { get; set; }

        //Gets the tenant for delete using a lamda 
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenant =  _context.Tenant.FirstOrDefault(m => m.Id == id);

            if (Tenant == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes tenant. selects tenant using a linq query.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenant = (from tenant in _context.Tenant
                      where tenant.Id == id
                      select tenant).FirstOrDefault();

            if (Tenant != null)
            {
                _context.Tenant.Remove(Tenant);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
