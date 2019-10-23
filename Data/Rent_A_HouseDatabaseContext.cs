using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;

namespace Rent_A_House.Models
{
    //The databse context which is responsible for connecting and mapping the business
    //layer objects via Entity framework.
    public class Rent_A_HouseDatabaseContext : DbContext
    {
        public Rent_A_HouseDatabaseContext (DbContextOptions<Rent_A_HouseDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Rent_A_House.BusinessLayer.Contract> Contract { get; set; }

        public DbSet<Rent_A_House.BusinessLayer.HouseOwner> HouseOwner { get; set; }

        public DbSet<Rent_A_House.BusinessLayer.House> House { get; set; }

        public DbSet<Rent_A_House.BusinessLayer.Tenant> Tenant { get; set; }
    }
}
