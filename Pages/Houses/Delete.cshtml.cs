using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Houses
{
    //Delete house
    public class DeleteModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DeleteModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Bind house .
        [BindProperty]
        public House House { get; set; }

        //Gets the house to delete.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            House = _context.House
                .Include(h => h.HouseOwner).FirstOrDefault(m => m.Id == id);

            if (House == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the house uses linq to get house record.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            House = (from house in _context.House
                     where house.Id ==  id select house).FirstOrDefault();

            if (House != null)
            {
                _context.House.Remove(House);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
