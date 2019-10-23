using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.HouseOwners
{
    //House owner update
    public class EditModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public EditModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Binds house owner.
        [BindProperty]
        public HouseOwner HouseOwner { get; set; }

        //Gets the house owner for update using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HouseOwner =  _context.HouseOwner.FirstOrDefault(m => m.Id == id);

            if (HouseOwner == null)
            {
                return NotFound();
            }
            return Page();
        }
        

        //Uodates the house owner
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HouseOwner).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseOwnerExists(HouseOwner.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks record using a lamda .
        private bool HouseOwnerExists(int id)
        {
            return _context.HouseOwner.Any(e => e.Id == id);
        }
    }
}
