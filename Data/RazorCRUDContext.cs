using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorCRUDApp.Entities;

namespace RazorCRUDApp.Data
{
    public class RazorCRUDContext : DbContext
    {
        public RazorCRUDContext(DbContextOptions<RazorCRUDContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
