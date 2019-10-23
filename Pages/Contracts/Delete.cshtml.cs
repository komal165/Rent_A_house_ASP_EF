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
    //Deletes the contract.
    public class DeleteModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public DeleteModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Binds the contract to the model.
        [BindProperty]
        public Contract Contract { get; set; }

        //Gets the contract to delete using a lamda query.
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


        //Deletes the contract uses linq query to select the contract.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = (from contract in _context.Contract
                        where contract.Id == id
                        select contract).FirstOrDefault();

            if (Contract != null)
            {
                _context.Contract.Remove(Contract);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
