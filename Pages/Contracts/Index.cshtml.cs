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
    //Show all contract.
    public class IndexModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public IndexModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Holds all contracts.
        public IList<Contract> Contract { get;set; }

        //Select all contracts using a lamda query.
        public void  OnGet()
        {
            Contract =  _context.Contract
                .Include(c => c.House)
                .Include(c => c.Tenant).ToList();
        }
    }
}
