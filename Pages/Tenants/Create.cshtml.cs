using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Tenants
{
    //Creates a Tenant.
    public class CreateModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public CreateModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Gets the tenant create form
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds tenant model.
        [BindProperty]
        public Tenant Tenant { get; set; }

        //Creates the tenant
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tenant.Add(Tenant);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}