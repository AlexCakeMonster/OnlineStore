using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }

        public DbSet<OrderReceiptAddress> OrderReceiptAddress { get; set; }

        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
