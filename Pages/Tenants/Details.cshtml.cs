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
    //Gets the details of tenant.
    public class DetailsModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DetailsModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Holds the tenant.
        public Tenant Tenant { get; set; }

        //Gets the tenant using a lamda query.
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
    }
}
