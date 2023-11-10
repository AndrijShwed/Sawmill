using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Пилорама.Models;

namespace Пилорама.Data
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

       
    }
}