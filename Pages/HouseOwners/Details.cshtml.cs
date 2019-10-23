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
    //Show the house owner details.
    public class DetailsModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DetailsModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //House owner details 
        public HouseOwner HouseOwner { get; set; }

        //Select house owner details using a lamda query.
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
    }
}
