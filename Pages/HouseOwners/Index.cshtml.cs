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
    //Show all hosue owners.
    public class IndexModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public IndexModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //House owner list
        public IList<HouseOwner> HouseOwner { get;set; }

        //Select all house owners using a linq query.
        public void OnGet()
        {
            HouseOwner = (from houseowner in _context.HouseOwner
                          select houseowner).ToList();

        }
    }
}
