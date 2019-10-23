using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Contracts
{
    //Show Contract details 
    public class DetailsModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DetailsModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Holds the contract
        public Contract Contract { get; set; }

        //Selects the contract using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract =  _context.Contract
                .Include(c => c.House)
                .Include(c => c.Tenant).FirstOrDefault(m => m.Id == id);

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
