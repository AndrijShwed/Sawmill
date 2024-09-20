using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sawmill.Models;

namespace Sawmill.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Number> Numbers { get; set; } = default!;
        public DbSet<Price> Prices { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<ServicePP> ServicePPs { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Contact> Contacts { get; set; } = default!;
    }
}