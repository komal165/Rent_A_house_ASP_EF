using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.HouseOwners
{
    //Deletes a house owner.
    public class DeleteModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DeleteModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Binds house owner property.
        [BindProperty]
        public HouseOwner HouseOwner { get; set; }

        //Gets the hosue owner for delete using a lamda query.
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

        //Removes the house owner uses linq to select house owner
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HouseOwner = (from houseOwner in _context.HouseOwner
                          where houseOwner.Id == id
                          select houseOwner).FirstOrDefault();

            if (HouseOwner != null)
            {
                _context.HouseOwner.Remove(HouseOwner);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
