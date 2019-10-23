using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.HouseOwners
{
    //Creates a HouseOwner.
    public class CreateModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public CreateModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Gets the house owner create form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the house owner 
        [BindProperty]
        public HouseOwner HouseOwner { get; set; }

        //Adds a house owner.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HouseOwner.Add(HouseOwner);
           _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}