using CarSell.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSell.AppDbContext
{
    public class CarDbContext : IdentityDbContext<IdentityUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> option)
            :base(option)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
