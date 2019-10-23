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
    //Get all houses 
    public class IndexModel : PageModel
    {
        private readonly Rent_A_House.Models.Rent_A_HouseDatabaseContext _context;

        public IndexModel(Rent_A_House.Models.Rent_A_HouseDatabaseContext context)
        {
            _context = context;
        }

        //List of houses
        public IList<House> House { get;set; }

        //Gets all houses using lamda 
        public void  OnGet()
        {
            House = _context.House
                .Include(h => h.HouseOwner).ToList();
        }
    }
}
