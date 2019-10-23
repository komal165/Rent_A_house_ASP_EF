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

namespace Rent_A_House.Pages.Contracts
{
    //Edits the contract.
    public class EditModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public EditModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Binds the contract
        [BindProperty]
        public Contract Contract { get; set; }

        //Select the contract for update using a lamda query.
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
           ViewData["HouseId"] = new SelectList(_context.Set<House>(), "Id", "HouseName",Contract.HouseId );
           ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "TenantRegistrationId", Contract.TenantId);
            return Page();
        }

        //Updates the contract record.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contract).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(Contract.Id))
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

        //Check the record exists using a lamda.
        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}
