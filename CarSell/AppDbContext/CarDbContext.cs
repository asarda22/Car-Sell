using CarSell.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSell.AppDbContext
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> option)
            :base(option)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
