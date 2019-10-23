using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Houses
{

    //Create a house
    public class CreateModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public CreateModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Get Create house form.
        public IActionResult OnGet()
        {
        ViewData["HouseOwnerId"] = new SelectList(_context.HouseOwner, "Id", "HouseOwnerRegistrationId");
            return Page();
        }

        //Binds house to model
        [BindProperty]
        public House House { get; set; }

        //Creates a house .
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.House.Add(House);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}