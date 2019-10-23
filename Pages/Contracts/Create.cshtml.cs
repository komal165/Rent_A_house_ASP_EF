using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Contracts
{
    //Creates a contract .
    public class CreateModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public CreateModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Returns the contract create form.
        public IActionResult OnGet()
        {
        ViewData["HouseId"] = new SelectList(_context.Set<House>(), "Id", "HouseName");
        ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "TenantRegistrationId");
            return Page();
        }

        //Binds the contract model.
        [BindProperty]
        public Contract Contract { get; set; }

        //Adds the contract to the databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contract.Add(Contract);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}