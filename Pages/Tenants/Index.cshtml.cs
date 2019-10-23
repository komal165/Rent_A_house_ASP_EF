using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House.Models;

namespace Rent_A_House.Pages.Tenants
{
    //Gets all tenants 
    public class IndexModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public IndexModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //Tenant List.
        public IList<Tenant> Tenant { get;set; }

        //Gets all tenants using a linq query.
        public void  OnGet()
        {
            Tenant = (from tenants in _context.Tenant select tenants).ToList(); ;
        }
    }
}
